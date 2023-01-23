using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    //třída sloužící jako kontejner pro údaje o historii tahu
    public class LogContainer
    {
        //prázdný konstruktér třídy
        public LogContainer() { }

        //aktivní strana (křížek nebo krožek)
        public SignsEnum Side { get; set; }

        //pozice na mapě (řádek)
        public int I { get; set; }

        //pozice na mapě (sloupec)
        public int J { get; set; }

        //je-li pravda tento tah je vítězný
        public bool IsWin { get; set; }
    }
}
