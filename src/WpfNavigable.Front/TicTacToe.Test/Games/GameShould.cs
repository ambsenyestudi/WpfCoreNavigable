using System;
using TicTacToe.Domain.Games;
using TicTacToe.Domain.Games.Agrgregate;
using Xunit;

namespace TicTacToe.Test.Games
{
    public class GameShould
    {
        [Fact]
        public void StartOnAnEmptyBoard()
        {
            var exptectedState = BoardState.Empty;
            var sut = new Game();
            var state = sut.GetBoardState();
            Assert.Equal(exptectedState, state);
        }
        [Fact]
        public void Start_Placing_X()
        {
            var exptectedResult = "X";
            var sut = new Game();
            var result = sut.Play(0, 0);
            Assert.Equal(exptectedResult, result);
        }
        [Fact]
        public void Place_O_After_X_Played()
        {
            var exptectedResult = "O";
            var sut = new Game();
            sut.Play(1, 0);
            var result = sut.Play(0, 0);
            Assert.Equal(exptectedResult, result);
        }
    }
}
