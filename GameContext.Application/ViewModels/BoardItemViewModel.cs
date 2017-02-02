using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameContext.Domain;

namespace GameContext.Application.ViewModels
{
    public class BoardItemViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static implicit operator BoardItemViewModel(BoardItem dm)
        {
            if(dm == null)
            {
                return new BoardItemViewModel();
            }
            var vm = new BoardItemViewModel()
            {
                X= dm.X,
                Y= dm.Y
            };
            return vm;
        }

        public  static implicit operator BoardItemViewModel (string input)
        {
            if (!input.Contains(" "))
            {
                throw new ArgumentException("Not in correct format");
            }
            try
            {
                var inputArr = input.Trim().Split(' ');

                return new BoardItemViewModel() { X = int.Parse(inputArr[0].Trim()), Y = int.Parse(inputArr[1].Trim()) };
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
    }
}
