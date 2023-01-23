using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace TicTacToe
{
    public partial class MainForm : Form
    {
        //herní mapa
        private TableMap TMap;

        private Bot GameBot;

        //historie tahu
        private List<List<LogContainer>> History;

        //konstruktér třídy
        public MainForm()
        {
            InitializeComponent();//inicializace

            History = new List<List<LogContainer>>();
            TMap = new TableMap();        
            TMap.ShowTiles(GamePanel);
            TMap.IsLock = true;
        }

        //Akce hra s botem
        private void StartGamePvB(object sender, EventArgs e)
        {
            if (GamePanel.BackgroundImage == null)//kontrola inicializace
                TMap.InitGrid(GamePanel);

            History.Add(new List<LogContainer>());//přidání partie do hystorie

            TMap.Clear();//čištění hry
            TMap.IsLock = false;
            TMap.OnAfterChange += TMapPvB_OnAfterChange;

            GameBot = new Bot(TMap);//vytvoření bot a předání mu mapy
        }

        //Hra s člověkem
        private void StartGamePvP(object sender, EventArgs e)
        {
            if (GamePanel.BackgroundImage == null)//kontrola inicializace
                TMap.InitGrid(GamePanel);

            History.Add(new List<LogContainer>());//přidání partie do hystorie

            TMap.Clear();//čištění hry
            TMap.IsLock = false;
            TMap.OnAfterChange += TMapPvP_OnAfterChange;
        }

        //Akce hra s botem
        private void TMapPvB_OnAfterChange(int I, int J)
        {            
            var winner = TMap.CheckWinner();//kontrola vítěze

            LogMove(TMap.ActiveSide, I, J, winner != SignsEnum.None);//zápis do historie poslední tah

            if (winner != SignsEnum.None)//pokud je určen vítěz
            {
                PrintWinner(winner);//ukazujeme vítěze
            }
            else if (!TMap.CheckEndGame())//pokud hra není u konce chodí bot
            {
                var botMove = GameBot.MakeMove();//pohyb bota

                winner = TMap.CheckWinner();//kontrola vítěze
                LogMove(SignsEnum.Zero, botMove.Item1, botMove.Item2, winner != SignsEnum.None);//zápis do historie

                if (winner != SignsEnum.None)//pokud je určen vítěz
                {
                    PrintWinner(winner);//ukazujeme vítěze
                }                
            }            
        }

        //Hra s člověkem
        private void TMapPvP_OnAfterChange(int I, int J)
        {                   
            var winner = TMap.CheckWinner();

            LogMove(TMap.ActiveSide, I, J, winner != SignsEnum.None);

            if (winner != SignsEnum.None)
            {
                PrintWinner(winner);
            }

            TMap.ActiveSide = TMap.ActiveSide == SignsEnum.Cross ? SignsEnum.Zero : SignsEnum.Cross;
        }

        //metoda pro zobrazení vítěze
        private void PrintWinner(SignsEnum Winner)
        {
            MessageBox.Show("Vyhral " + (Winner == SignsEnum.Cross ? "krizek" : "krouzek"));
        }

        //historie tahu
        private void LogMove(SignsEnum Val, int I, int J, bool IsWin)
        {
            var last = History.Last();
            last.Add(new LogContainer() { Side = Val, I = I, J = J, IsWin = IsWin }); 
        }

        //XML
        private void XmlExport(object sender, EventArgs e)
        {          
            using (var sf = new SaveFileDialog())
            {
                sf.Filter = "xml (*.xml)|*.xml";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    var formatter = new XmlSerializer(typeof(List<List<LogContainer>>));
                    var fileName = sf.FileName;

                    using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(stream, History);

                        MessageBox.Show(fileName + " uloženo");
                    }                        
                }
            }                
        }

        //CSV
        private void CsvExport(object sender, EventArgs e)
        {
            using (var sf = new SaveFileDialog())
            {
                sf.Filter = "csv (*.csv)|*.csv";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    var fileName = sf.FileName;

                    using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
                    {                        
                        using (var sw = new StreamWriter(stream))
                        {
                            sw.WriteLine("Partie cislo,Hrac,Souradnice,Vitezny tah");

                            var counter = 2;
                            var roundCounter = 1;

                            foreach (var i in History)
                            {
                                foreach (var j in i)
                                {
                                    sw.Write(roundCounter.ToString() + ",");
                                    sw.Write((j.Side == SignsEnum.Cross ? "krizek" : "krouzek") + ",");
                                    sw.Write(j.I + ":" + j.J + ",");
                                    sw.Write(j.IsWin ? "Ano" : "Ne");
                                    sw.WriteLine();

                                    counter++;
                                }

                                roundCounter++;
                                counter++;
                            }
                        }

                        MessageBox.Show(fileName + " uloženo");
                    }
                }
            }            
        }
    }
}
