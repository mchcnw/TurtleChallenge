using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameContext.Domain;

namespace GameContext.Application.ViewModels
{
    public class GameViewModel
    {
        public BoardItemViewModel ExitPoint { get;  set; }

        public TurtleViewModel Turtle { get;  set; }

        public IEnumerable<BoardItemViewModel> Mines { get;  set; }

        public BoardViewModel Board { get;  set; }

        public IEnumerable<char> Moves { get; set; }

        public bool IsOver { get; set; }

        public bool HasErrors { get; set; }

        public string Outcome { get; set; }

        public int LastAction { get;  set; }

    

        public static implicit operator GameViewModel(Game dm)
        {
            if (dm == null)
            {
                return new GameViewModel();
            }
            var vm = new GameViewModel()
            {
                ExitPoint = dm.ExitPoint,
                Turtle = dm.Turtle,
                Board = dm.Board,
                Mines = dm.Mines.Select(m => new BoardItemViewModel() {X = m.X, Y = m.Y}),
                IsOver = dm.IsOver,
                HasErrors = dm.HasError,
                Outcome = dm.Outcome,
                LastAction = dm.LastAction,
                Moves = dm.Actions

            };
            return vm;
        }
}
}
