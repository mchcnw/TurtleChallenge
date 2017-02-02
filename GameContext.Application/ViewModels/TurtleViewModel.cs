using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameContext.Domain;

namespace GameContext.Application.ViewModels
{
    public class TurtleViewModel
    {
        public int X { get;  set; }
        public int Y { get;  set; }

        public string Direction { get;  set; }

        public static implicit operator TurtleViewModel(Turtle dm)
        {
            if (dm == null)
            {
                return new TurtleViewModel();
            }
            var vm = new TurtleViewModel()
            {
                X = dm.X,
                Y = dm.Y,
                Direction = dm.Direction

            };
            return vm;
        }

        public static implicit operator TurtleViewModel (string input)
        {
            if (!input.Contains(" "))
            {
                throw new ArgumentException("Not in correct format");
            }
            try
            {
                var inputArr = input.Split(' ');

                return new TurtleViewModel() { X = int.Parse(inputArr[0].Trim()), Y = int.Parse(inputArr[1].Trim()), Direction = inputArr[2].Trim() };
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
    }
}
