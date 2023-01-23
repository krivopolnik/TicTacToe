using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TicTacToe
{
    //třída mapy
    class TableMap
    {
        //pole
        public Tile[,] Map { get; set; }

        
        public SignsEnum ActiveSide { get; set; }

        
        public bool IsLock { get; set; }

        
        public event Action<int, int> OnAfterChange 
        { 
            add 
            {
                
                for (var i = 0; i < 3; ++i)
                {
                    for (var j = 0; j < 3; ++j)
                    {
                        Map[i, j].OnAfterChange += value;
                    }
                }
            }

            remove 
            {
                
                for (var i = 0; i < 3; ++i)
                {
                    for (var j = 0; j < 3; ++j)
                    {
                        Map[i, j].OnAfterChange -= value;
                    }
                }
            } 
        }

        //konstruktér třídy
        public TableMap()
        {
            ActiveSide = SignsEnum.Cross;

            Map = new Tile[3, 3];//vytvoří se pole 3x3

            for (var i = 0; i < 3; ++i)
            {
                for (var j = 0; j < 3; ++j)
                {
                    Map[i, j] = new Tile(this);
                }
            }
        }

        //metoda inicializace mřížky na herním panelu
        public void InitGrid(Panel GamePanel)
        {
            var img = new Bitmap(GamePanel.Width, GamePanel.Height);
            var g = Graphics.FromImage(img); 

            var w = GamePanel.Width / 3;//šířka
            var h = GamePanel.Height / 3;//výška

            for (var i = 1; i < 3; ++i)
            {
                g.DrawLine(new Pen(Brushes.Black, 4), i * w - 2, 0, i * w - 2, GamePanel.Height);
                g.DrawLine(new Pen(Brushes.Black, 4), 0, i * h - 2, GamePanel.Width, i * h - 2);
            }

            g.Dispose();
            GamePanel.BackgroundImage = img;
        }

        
        public void ShowTiles(Panel GamePanel)
        {           
            var w = GamePanel.Width / 3;
             var h = GamePanel.Height / 3;

            for (var i = 0; i < 3; ++i)
            {
                for (var j = 0; j < 3; ++j)
                {
                    Map[i, j].ShowToPanel(GamePanel, j * w, i * h, w - 4, h - 4);
                }
            }
        }

        //metoda čištění
        public void Clear()
        {
            for (var i = 0; i < 3; ++i)
            {
                for (var j = 0; j < 3; ++j)
                {
                    Map[i, j].Clear();
                }
            }

            ActiveSide = SignsEnum.Cross;//nastavíme křížek jako aktivního hráče
        }

        //metoda pro kontrolu konce hry
        public bool CheckEndGame()
        {
            for (var i = 0; i < 3; ++i)
            {
                for (var j = 0; j < 3; ++j)
                {
                    if (Map[i, j].Value == SignsEnum.None)
                        return false;        
                }
            }

            return true;
        }

        //metoda určení vítěze
        public SignsEnum CheckWinner()
        {
            //cykly kontroly vítěze vodorovně a svisle
            for (var i = 0; i < 3; ++i)
            {
                var vertical = true;
                var verticalVal = SignsEnum.None;
                var horizon = true;
                var horizonlVal = SignsEnum.None;

                for (var j = 0; j < 2; ++j)
                {
                    if (Map[i, j].Value != Map[i, j + 1].Value)
                        horizon = false;
                    else
                        horizonlVal = Map[i, j].Value;

                    if (Map[j, i].Value != Map[j + 1, i].Value)
                        vertical = false;
                    else
                        verticalVal = Map[j, i].Value;
                }

                if (vertical && verticalVal != SignsEnum.None)
                    return verticalVal;

                if (horizon && horizonlVal != SignsEnum.None)
                    return horizonlVal;
            }

            //kontrola vítězů diagonálně
            var left = true;
            var leftVal = SignsEnum.None;
            var right = true;
            var rightVal = SignsEnum.None;

            for (var i = 0; i < 2; ++i) 
            {
                if (Map[i, i].Value != Map[i + 1, i + 1].Value)
                    left = false;
                else
                    leftVal = Map[i, i].Value;

                if (Map[i, 2 - i].Value != Map[i + 1, 2 - (i + 1)].Value)
                    right = false;
                else
                    rightVal = Map[i, 2 - i].Value;
            }

            if (left && leftVal != SignsEnum.None)
                return leftVal;

            if (right && rightVal != SignsEnum.None)
                return rightVal;

            return SignsEnum.None;
        }
    }
}
