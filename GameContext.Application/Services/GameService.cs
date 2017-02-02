using System;
using System.Collections.Generic;
using System.Linq;
using GameContext.Application.ViewModels;
using GameContext.Domain;

namespace GameContext.Application.Services
{
    public class GameService
    {
        public GameViewModel Start(BoardViewModel board, TurtleViewModel turtle,BoardItemViewModel exitPoint, IEnumerable<BoardItemViewModel> mines)
        {
            return Game.Create(board.N, board.M, turtle.X, turtle.Y, turtle.Direction, mines.Select(m => new Tuple<int, int>(m.X, m.Y)), exitPoint.X, exitPoint.Y);
          
        }

        public GameViewModel Move(string moves, GameViewModel game)
        {
            return Game.Move(moves, Game.Create(game.Board.N, game.Board.M, game.Turtle.X, game.Turtle.Y, game.Turtle.Direction, game.Mines.Select(m => new Tuple<int, int>(m.X, m.Y)), game.ExitPoint.X, game.ExitPoint.Y));
        }
    }
}
