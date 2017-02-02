using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameContext.Domain;

namespace GameContext.Application.ViewModels
{
   public  class BoardViewModel
    {
        public int N { get;  set; }
        public int M { get;  set; }

       public static implicit operator BoardViewModel(Board dm)
       {
           if (dm == null)
           {
               return new BoardViewModel();
           }
           var vm = new BoardViewModel()
           {
               N = dm.N,
               M = dm.M
           };
           return vm;
       }

        public static implicit operator BoardViewModel(string input)
        {
            if (!input.Contains(" "))
            {
                throw new ArgumentException("Not in correct format");
            }
            try
            {
                var inputArr = input.Split(' ');

                return new BoardViewModel() { N = int.Parse(inputArr[0].Trim()), M = int.Parse(inputArr[1].Trim()) };
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
    }
}
