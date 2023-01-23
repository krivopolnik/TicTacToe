using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TicTacToe
{
    
    class Tile
    {
        //ukládání obrázků krizek
        private static Bitmap Cr { get; set; }

        //ukládání obrázků krouzek
        private static Bitmap Ze { get; set; }

        //inicializace statických polí třídy
        static Tile()
        {
            Cr = new Bitmap("Pics\\Cr.png");//vytvoření objektu obrázku krizek
            Ze = new Bitmap("Pics\\Ze.png");//vytvoření objektu obrázku krouzek
        }

        //kreslení obrázků
        private PictureBox PicBox;

        
        public SignsEnum Value { get; set; }

        //uložení společného objektu herní karty
        public TableMap Map { get; set; }

        
        public event Action<int, int> OnAfterChange;

        //konstruktér třídy
        public Tile(TableMap Mapa)
        {
            Map = Mapa;//uložení objektu do pole třídy 
            Value = SignsEnum.None;
            PicBox = new PictureBox();
            PicBox.BackgroundImageLayout = ImageLayout.Zoom;
            PicBox.Click += PicBox_Click;
        }

        //metoda pro přihlášení k události kliknutí
        private void PicBox_Click(object sender, EventArgs e)
        {
            
            if (Value != SignsEnum.None)
                return;
            
            var side = Map.ActiveSide;//přechod tahu (krizek nebo krouzek)
            SetValue(side);

            
            if (OnAfterChange != null)
            {
                
                var x = PicBox.Left;
                var y = PicBox.Top;
                var w = PicBox.Width;
                var h = PicBox.Height;

                
                OnAfterChange(x / w, y / h);
            }
        }

        
        public void ShowToPanel(Panel GamePanel, int X, int Y, int W, int H)
        {
            PicBox.Left = X;
            PicBox.Top = Y;
            PicBox.Width = W;
            PicBox.Height = H;
            PicBox.Parent = GamePanel;
        }

        //metoda pro nastavení hodnoty
        public void SetValue(SignsEnum Val)
        {
            
            if (Map.IsLock)
                return;

            
            Value = Val;

            
            switch (Val)
            {
                case SignsEnum.Cross:
                    PicBox.BackgroundImage = Cr;
                    break;
                case SignsEnum.Zero:
                    PicBox.BackgroundImage = Ze;
                    break;
            }            
        }

        
        public void Clear()
        {
            Value = SignsEnum.None;
            PicBox.BackgroundImage = null;
            OnAfterChange = null;
        }
    }
}
