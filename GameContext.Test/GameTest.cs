using System;
using System.Collections.Generic;
using GameContext.Application.Services;
using GameContext.Application.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameContext.Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestTurtleSucceeds()
        {
            //arrange
            var board = new BoardViewModel() {N = 10, M =10};
            var turtle = new TurtleViewModel() {Direction = "North", X = 1, Y = 1};
            var exitPoint = new BoardItemViewModel() {X = 1 , Y = 3};
            var mines = new List<BoardItemViewModel>() ;
            mines.Add(new BoardItemViewModel() { X = 4, Y = 5 });
            var moves = "mmmm";
            var gameService = new GameService();

            //act
            var mockGame = gameService.Start(board, turtle, exitPoint, mines);
            mockGame = gameService.Move(moves, mockGame);
            //assert
            Assert.IsTrue(mockGame.Outcome == "Success!");
            Assert.IsTrue(mockGame.IsOver);
        }

        [TestMethod]
        public void TestTurtleFails()
        {
            //arrange
            var board = new BoardViewModel() { N = 10, M = 10 };
            var turtle = new TurtleViewModel() { Direction = "North", X = 1, Y = 1 };
            var exitPoint = new BoardItemViewModel() { X = 4, Y = 5 };
            var mines = new List<BoardItemViewModel>();
            mines.Add(new BoardItemViewModel() { X = 1, Y = 3 });
            var moves = "mmmm";
            var gameService = new GameService();

            //act
            var mockGame = gameService.Start(board, turtle, exitPoint, mines);
            mockGame = gameService.Move(moves, mockGame);
            //assert
            Assert.IsTrue(mockGame.Outcome == "Fail!");
            Assert.IsTrue(mockGame.IsOver);
        }

        [TestMethod]
        public void TestTurtleOffTheBoard()
        {
            //arrange
            var board = new BoardViewModel() { N = 2, M = 2 };
            var turtle = new TurtleViewModel() { Direction = "North", X = 1, Y = 1 };
            var exitPoint = new BoardItemViewModel() { X = 4, Y = 5 };
            var mines = new List<BoardItemViewModel>();
            mines.Add(new BoardItemViewModel() { X = 2, Y = 2 });
            var moves = "mmmmrrrmmmmmmm";
            var gameService = new GameService();

            //act
            var mockGame = gameService.Start(board, turtle, exitPoint, mines);
            mockGame = gameService.Move(moves, mockGame);
            //assert
            Assert.IsTrue(mockGame.Outcome == "Moved off the board!");
            Assert.IsTrue(mockGame.IsOver);
        }

        [TestMethod]
        public void TestTurtleCanContinue()
        {
            //arrange
            var board = new BoardViewModel() { N = 20, M = 20 };
            var turtle = new TurtleViewModel() { Direction = "North", X = 1, Y = 1 };
            var exitPoint = new BoardItemViewModel() { X = 4, Y = 5 };
            var mines = new List<BoardItemViewModel>();
            mines.Add(new BoardItemViewModel() { X = 2, Y = 2 });
            var moves = "m";
            var gameService = new GameService();

            //act
            var mockGame = gameService.Start(board, turtle, exitPoint, mines);
            mockGame = gameService.Move(moves, mockGame);
            //assert
            Assert.IsTrue(mockGame.Outcome == "Continue");
            Assert.IsFalse(mockGame.IsOver);
        }
    }
}
