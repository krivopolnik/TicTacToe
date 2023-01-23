using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    //třída Bot
    class Bot
    {        
        private TableMap Map;//mapa
                            
        private Random Rnd; //objekt random

        //konstruktér třídy
        public Bot(TableMap TMap)
        {
            Map = TMap;//uložení objektu do pole třídy 

            Rnd = new Random();//vytvoření objektu random
        }

        //metoda pohybu bota
        public Tuple<int, int> MakeMove()
        {
            var winnMove = GetWinningMove();//vítězný tah
            if (winnMove.Item3 != SignsEnum.None)//pokud existuje vítězný tah
            {
                Map.Map[winnMove.Item1, winnMove.Item2].SetValue(SignsEnum.Zero);//dáme tam kroužek
                return Tuple.Create(winnMove.Item1, winnMove.Item2);//návrat znaku
            }
            else //jinak náhodný pohyb
            {
                SignsEnum tileValue;//proměnná pro uložení znaku na hrací ploše

                do
                {
                    var i = Rnd.Next(3);//vertikálně
                    var j = Rnd.Next(3);//vodorovně

                    tileValue = Map.Map[i, j].Value;//zachovat souřadnice
                    if (tileValue == SignsEnum.None)//pokud buňka je prázdná
                    {
                        Map.Map[i, j].SetValue(SignsEnum.Zero);//dáme tam kroužek  
                        return Tuple.Create(i, j);//návrat souřadnic buňky
                    }
                }
                while (tileValue != SignsEnum.None);//hledání prázdné buňky
            }

            return Tuple.Create(-1, -1);//návrat souřadnic buňky
        }

        //metoda získání vítězného tahu
        private Tuple<int, int, SignsEnum> GetWinningMove()
        {
            var map = Map.Map;

            //hledání vítězného tahu vertikálně a horizontálně
            for (var i = 0; i < 3; ++i)
            {
                var horyIndex = -1;
                var horyValue = SignsEnum.None;
                var verIndex = -1;
                var verValue = SignsEnum.None;

                for (var j = 0; j < 3; ++j)
                {
                    if (map[i, j].Value == SignsEnum.None)
                    {
                        if (horyIndex == -1)
                            horyIndex = j;
                        else
                            horyIndex = -2;
                    }
                    else if (horyValue == SignsEnum.None)
                    {
                        horyValue = map[i, j].Value;
                    }
                    else if (horyValue != map[i, j].Value)
                    {
                        horyIndex = -2;
                    }

                    if (map[j, i].Value == SignsEnum.None)
                    {
                        if (verIndex == -1)
                            verIndex = j;
                        else
                            verIndex = -2;
                    }
                    else if (verValue == SignsEnum.None)
                    {
                        verValue = map[j, i].Value;
                    }
                    else if (verValue != map[j, i].Value)
                    {
                        verIndex = -2;
                    }
                }

                if (horyIndex > -1)
                    return Tuple.Create(i, horyIndex, horyValue);

                if (verIndex > -1)
                    return Tuple.Create(verIndex, i, verValue);
            }

            //hledání vítězného tahu diagonálně
            var leftIndex = -1;
            var leftVal = SignsEnum.None;
            var rightIndex = -1;
            var rightVal = SignsEnum.None;

            for (var i = 0; i < 3; ++i)
            {
                if (map[i, i].Value == SignsEnum.None)
                {
                    if (leftIndex == -1)
                        leftIndex = i;
                    else
                        leftIndex = -2;
                }
                else if (leftVal == SignsEnum.None)
                {
                    leftVal = map[i, i].Value;
                }
                else if (leftVal != map[i, i].Value)
                {
                    leftIndex = -2;
                }

                if (map[i, 2 - i].Value == SignsEnum.None)
                {
                    if (rightIndex == -1)
                        rightIndex = i;
                    else
                        rightIndex = -2;
                }
                else if (rightVal == SignsEnum.None)
                {
                    rightVal = map[i, 2 - i].Value;
                }
                else if (rightVal != map[i, 2 - i].Value)
                {
                    rightIndex = -2;
                }
            }

            if (leftIndex > -1)
                return Tuple.Create(leftIndex, leftIndex, leftVal);

            if (rightIndex > -1)
                return Tuple.Create(rightIndex, 2 - rightIndex, rightVal);

            return Tuple.Create(0, 0, SignsEnum.None);
        }
    }
}
