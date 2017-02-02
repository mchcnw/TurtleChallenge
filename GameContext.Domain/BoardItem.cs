using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GameContext.Domain
{
    public class BoardItem
    {
        public BoardItem(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public static  BoardItem Create (int x, int y )
        {
            return new BoardItem(x, y);
        }

    }
}
