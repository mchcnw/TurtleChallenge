using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GameContext.Domain
{
    public class Game
    {
        private List<BoardItem> _mines;
        private List<char> _actions = new List<char>();



        private Game(Board board,Turtle turtle, BoardItem exitPoint, IEnumerable<BoardItem> mines )
        {
            Board = board;
            Turtle = turtle;
            ExitPoint = exitPoint;
            _mines = new List<BoardItem>(mines.Select(m => new BoardItem(m.X, m.Y)));
        }

        private Game(Board board, Turtle turtle, BoardItem exitPoint, IEnumerable<BoardItem> mines,int actionIndex, IEnumerable<char> actions, string outcome, bool isOver):this(board,turtle,exitPoint, mines)
        {
            LastAction = actionIndex;
            Outcome = outcome;
            _actions =new List<char>(actions);
            IsOver = isOver;
        }

        private Game(string outcome)
        {
            Outcome = outcome;
          
        }


        public static Game Create(int sizeN, int sizeM, int startingPointX, int startingPointY, string startingDirection, IEnumerable<Tuple<int, int>> minesCordTuples, int exitPointX, int exitPointY )
        {
            var board = Board.Create(sizeN, sizeM);
             var turtle = Turtle.Create(startingPointX, startingPointY, startingDirection);
            
            var exitPoint = BoardItem.Create(exitPointX, exitPointY);
            var mines = minesCordTuples.Select(x => new BoardItem(x.Item1, x.Item2));
            return new Game(board,turtle,exitPoint,mines);
        }


        private static Game ValidatePosition(Game game)
        {
       
            if (!Board.IsCellValid(game.Turtle.X,game.Turtle.Y, game.Board.N, game.Board.M))
            {
                return new Game(game.Board, game.Turtle, game.ExitPoint, game.Mines, game.LastAction, game.Actions, "Moved off the board!", true);
            }

            return game;
        }

       

       


        public static Game Play(int actionIndex, Board board, Turtle turtle,IEnumerable<BoardItem> mines, BoardItem exit, IEnumerable<char> actions)
        {
            if (turtle.X == exit.X && turtle.Y == exit.Y)
            {
                return new Game(board,turtle, exit, mines, actionIndex, actions, "Success!", true);
            }
            if (mines.Any(m => turtle.X == m.X && turtle.Y == m.Y))
            {
                return new Game(board, turtle, exit, mines, actionIndex, actions, "Fail!", true);
            }
            return new Game(board, turtle, exit, mines, actionIndex, actions, "Continue", false);
        }

        public static Game Move(string moves, Game game)
        {
            var actions = moves.ToCharArray();
            var currentGame = new Game(game.Board,game.Turtle, game.ExitPoint, game.Mines);
            var turtle = Turtle.Create(game.Turtle.X, game.Turtle.Y, game.Turtle.Direction);
            var index = 0;
            foreach (var action in actions)
            {
                
                turtle = Turtle.Move(action, turtle);
                
                currentGame = ValidatePosition(Play(index++, game.Board, turtle, game.Mines, game.ExitPoint, actions));
                if (currentGame.IsOver ||currentGame.HasError)
                {
                    return currentGame;
                }
            }
            return currentGame;
        }

      

        public BoardItem ExitPoint { get; private set; }

        public Turtle Turtle { get; private set; }

        public IEnumerable<BoardItem> Mines => _mines;

        public Board Board { get; private set; }

        public IEnumerable<char> Actions => _actions;

        public string Outcome { get; private set; }

        public int LastAction { get; private set; }
        public bool IsOver  { get; private set; }

        public bool HasError  { get; private set; }



    }
}
