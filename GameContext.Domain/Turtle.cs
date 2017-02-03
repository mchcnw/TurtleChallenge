using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameContext.Domain
{
    public class Turtle
    {
        public Turtle()
        {
            
        }

        private Turtle(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public static Turtle Create(int x, int y, string direction)
        {
            return new Turtle(x, y, direction);
        }

       

        public int X { get; private set; }
        public int Y { get; private set; }

        public string Direction { get; private set; }

        
        public string[] Directions => new [] {"North", "East", "South", "West"};

        public static Turtle Move(char action, Turtle turtle)
        {
            if (action == 'r')
            {
                var index = Array.IndexOf(turtle.Directions, turtle.Direction);
                return new Turtle(turtle.X, turtle.Y, turtle.Directions[index ==3?0:index+1]);
            }
            if (action == 'm')
            {
                if (turtle.Direction == "North")
                {
                    return new Turtle(turtle.X, turtle.Y + 1, turtle.Direction);
                }
                if (turtle.Direction == "South")
                {
                    return new Turtle(turtle.X, turtle.Y - 1, turtle.Direction);
                }
                if (turtle.Direction == "East")
                {
                    return new Turtle(turtle.X + 1, turtle.Y, turtle.Direction);
                }
                if (turtle.Direction == "West")
                {
                    return new Turtle(turtle.X - 1, turtle.Y, turtle.Direction);
                }
           
            }
            return new Turtle(turtle.X, turtle.Y, turtle.Direction);
        }
    }
}
