using System;
using TicTacToe.Domain;
using TicTacToe.Domain.Games;
using TicTacToe.Domain.Games.Agrgregate;
using Xunit;

namespace TicTacToe.Test.Games
{
    public class GameShould
    {
        private const string GAME_ID_VALUE = "a2ea6b26-17ea-403b-8538-6b14662f0b00";
        private const string X_WON = "XWon";
        private const string O_WON = "OWon";
        private const string DRAW = "Draw";
        public GameId Id { get; } = GameId.Create(new Guid(GAME_ID_VALUE));

        [Fact]
        public void StartOnAnEmptyBoard()
        {
            var exptectedState = BoardState.Empty;
            var sut = new Game(Id);
            var state = sut.GetBoardState();
            Assert.Equal(exptectedState, state);
        }
        [Fact]
        public void Start_Placing_X()
        {
            var exptectedResult = "X";
            var sut = new Game(Id);
            
            var result = sut.Play(BoardRowColumn.Create(0,0));
            Assert.Equal(exptectedResult, result);
        }
        [Fact]
        public void Place_O_After_X_Played()
        {
            var exptectedResult = "O";
            var sut = new Game(Id);
            sut.Play(BoardRowColumn.Create(1, 0));
            var result = sut.Play(BoardRowColumn.Create(0, 0));
            Assert.Equal(exptectedResult, result);
        }
        [Fact]
        public void Not_Play_A_Played_Position()
        {
            var sut = new Game(Id);
            sut.Play(BoardRowColumn.Create(0, 0));
            Assert.Throws<PostionAlreadyPlayedException>(() => sut.Play(BoardRowColumn.Create(0, 0)));
        }
        [Theory]
        [InlineData(
            X_WON,
            "X,X,X," +
            "O,O,"+
            ",,")]
        [InlineData(
            X_WON,
            "O,,," +
            "X,X,X," +
            "O,,")]
        [InlineData(
            X_WON,
            "O,,," +
            "O,,," +
            "X,X,X")]        
        [InlineData(
            O_WON,
            "O,O,O," +
            "X,X,," +
            "X,X,")]        
        [InlineData(
            O_WON,
            "X,X,," +
            "O,O,O," +
            "X,X,")]
        [InlineData(
            O_WON,
            "X,X,," +
            "X,X,," +
            "O,O,O,")]
        public void Tell_Who_Wins_Rows(string expectedStatus, string gameLayout)
        {
            GameStatus.TryParse(expectedStatus, out GameStatus expectedGameStatus);
            var sut = new Game(Id, gameLayout);
            var actual = sut.GetStatus();
            Assert.Equal(expectedGameStatus, actual);
        }
        
        [Theory]
        [InlineData(
            X_WON,
            "X,O,," +
            "X,O,," +
            "X,,")]
        [InlineData(
            X_WON,
            "O,X,," +
            "O,X,," +
            ",X,")]
        [InlineData(
            X_WON,
            "O,,X," +
            "O,,X," +
            ",,X")]
        [InlineData(
            O_WON,
            "O,X,X," +
            "O,X,X," +
            "O,,")]
        [InlineData(
            O_WON,
            "X,O,X," +
            "X,O,X," +
            ",O,")]
        [InlineData(
            O_WON,
            "X,X,O," +
            "X,X,O," +
            ",,O")]
        public void Tell_Who_Wins_Columns(string expectedStatus, string gameLayout)
        {
            GameStatus.TryParse(expectedStatus, out GameStatus expectedGameStatus);
            var sut = new Game(Id, gameLayout);
            var actual = sut.GetStatus();
            Assert.Equal(expectedGameStatus, actual);
        }
        [Theory]
        [InlineData(
            X_WON,
            "X,O,," +
            "O,X,," +
            ",,X")]
        [InlineData(
            X_WON,
            ",O,X," +
            "O,X,," +
            "X,,")]
        [InlineData(
            O_WON,
            "O,X,," +
            ",O,X," +
            "X,,O")]
        [InlineData(
            O_WON,
            "X,,O," +
            ",O,X," +
            "O,X,")]
        public void Tell_Who_Wins_Diagonals(string expectedStatus, string gameLayout)
        {
            GameStatus.TryParse(expectedStatus, out GameStatus expectedGameStatus);
            var sut = new Game(Id, gameLayout);
            var actual = sut.GetStatus();
            Assert.Equal(expectedGameStatus, actual);
        }

        [Theory]
        [InlineData(
            DRAW,
            "X,X,O," +
            "O,X,X," +
            "X,O,O")]
        [InlineData(
            DRAW,
            "X,O,X," +
            "O,X,X," +
            "O,X,O")]
        public void Should_Draw_When_No_Winner(string expectedStatus, string gameLayout)
        {
            GameStatus.TryParse(expectedStatus, out GameStatus expectedGameStatus);
            var sut = new Game(Id, gameLayout);
            var actual = sut.GetStatus();
            Assert.Equal(expectedGameStatus, actual);
        }
    }
}
