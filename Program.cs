using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameContext.Application.Services;
using GameContext.Application.ViewModels;

namespace TurtleChallenge.ConsoleApp
{
    class Program
    {
        private static GameService _gameService;

         static Program()
        {
            _gameService = new GameService();
        }
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Board?:");
            BoardViewModel board = Console.ReadLine();
            Console.WriteLine("Starting position?:");
            TurtleViewModel turtle = Console.ReadLine();
            Console.WriteLine("Exit point?:");
            BoardItemViewModel exitPoint = Console.ReadLine();
            Console.WriteLine("Mines?:");
            var mines = new List<BoardItemViewModel>();
            var mineInputs = Console.ReadLine()?.Split(',');
            if (mineInputs != null)
            {
                mines.AddRange(mineInputs.Select(mineInput => (BoardItemViewModel)mineInput));
            }
            DisplayOutput(StartGame(board, turtle, exitPoint, mines));
        }

        private static GameViewModel StartGame(BoardViewModel board, TurtleViewModel turtle, BoardItemViewModel exitPoint, List<BoardItemViewModel> mines)
        {
            var game = StartGame(board, turtle, exitPoint, (IEnumerable<BoardItemViewModel>) mines);
            while (game != null && !game.IsOver && !game.HasErrors)
            {
                Console.WriteLine("Moves?:");
                var moves = Console.ReadLine();
                game = Move(moves, game);
            }

            return game;
        }

        private static void DisplayOutput(GameViewModel game)
        {
            var movesOutput = new string(game.Moves.ToArray());
            Console.Write(game.Outcome);
            Console.Write(movesOutput.Substring(0, game.LastAction));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(movesOutput.Substring(game.LastAction, 1));
            Console.ResetColor();
            Console.Write(movesOutput.Substring(game.LastAction + 1));
            Console.ReadLine();
        }


        private static GameViewModel StartGame(BoardViewModel board, TurtleViewModel turtle, BoardItemViewModel exitPoint, IEnumerable<BoardItemViewModel> mines )
        {
            return  _gameService.Start(board, turtle, exitPoint, mines);
            
        }

        private static GameViewModel Move(string moves, GameViewModel game)
        {
            return _gameService.Move(moves, game);

        }


    }
    }

