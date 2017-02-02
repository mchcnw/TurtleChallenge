using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameContext.Domain
{
    public class Board
    {
        private Board(int n, int m)
        {
            N = n;
            M = m;
        }

    

        public int N { get; private set; }
        public int M { get; private set; }

       
        public static Board Create(int n, int m)
        {
            return new Board(n, m);
        }


        public static bool IsCellValid(int x, int y, int boardN, int boardM)
        {
             return (x >= 0) && (y >= 0) && (x < boardN) && (y < boardM);
        }


    }
}
