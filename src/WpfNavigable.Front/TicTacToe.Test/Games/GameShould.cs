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
            
            var result = sut.Play(BoardRowColumn.Create(0,0));
            Assert.Equal(exptectedResult, result);
        }
        [Fact]
        public void Place_O_After_X_Played()
        {
            var exptectedResult = "O";
            var sut = new Game();
            sut.Play(BoardRowColumn.Create(1, 0));
            var result = sut.Play(BoardRowColumn.Create(0, 0));
            Assert.Equal(exptectedResult, result);
        }
        [Fact]
        public void Not_Play_A_Played_Position()
        {
            var sut = new Game();
            sut.Play(BoardRowColumn.Create(0, 0));
            Assert.Throws<PostionAlreadyPlayedException>(() => sut.Play(BoardRowColumn.Create(0, 0)));
        }
        [Theory]
        [InlineData(
            GameStatus.XWon,
            "X,X,X," +
            "O,O,"+
            ",,")]
        [InlineData(
            GameStatus.XWon,
            "O,,," +
            "X,X,X," +
            "O,,")]
        [InlineData(
            GameStatus.XWon,
            "O,,," +
            "O,,," +
            "X,X,X")]        
        [InlineData(
            GameStatus.OWon,
            "O,O,O," +
            "X,X,," +
            "X,X,")]        
        [InlineData(
            GameStatus.OWon,
            "X,X,," +
            "O,O,O," +
            "X,X,")]
        [InlineData(
            GameStatus.OWon,
            "X,X,," +
            "X,X,," +
            "O,O,O,")]
        public void Tell_Who_Wins_Rows(GameStatus expectedGameStatus, string gameLayout)
        {
            var sut = new Game(gameLayout);
            var actual = sut.GetStatus();
            Assert.Equal(expectedGameStatus, actual);
        }
        
        [Theory]
        [InlineData(
            GameStatus.XWon,
            "X,O,," +
            "X,O,," +
            "X,,")]
        [InlineData(
            GameStatus.XWon,
            "O,X,," +
            "O,X,," +
            ",X,")]
        [InlineData(
            GameStatus.XWon,
            "O,,X," +
            "O,,X," +
            ",,X")]
        [InlineData(
            GameStatus.OWon,
            "O,X,X," +
            "O,X,X," +
            "O,,")]
        [InlineData(
            GameStatus.OWon,
            "X,O,X," +
            "X,O,X," +
            ",O,")]
        [InlineData(
            GameStatus.OWon,
            "X,X,O," +
            "X,X,O," +
            ",,O")]
        public void Tell_Who_Wins_Columns(GameStatus expectedGameStatus, string gameLayout)
        {
            var sut = new Game(gameLayout);
            var actual = sut.GetStatus();
            Assert.Equal(expectedGameStatus, actual);
        }
        [Theory]
        [InlineData(
            GameStatus.XWon,
            "X,O,," +
            "O,X,," +
            ",,X")]
        [InlineData(
            GameStatus.XWon,
            ",O,X," +
            "O,X,," +
            "X,,")]
        [InlineData(
            GameStatus.OWon,
            "O,X,," +
            ",O,X," +
            "X,,O")]
        [InlineData(
            GameStatus.OWon,
            "X,,O," +
            ",O,X," +
            "O,X,")]
        public void Tell_Who_Wins_Diagonals(GameStatus expectedGameStatus, string gameLayout)
        {
            var sut = new Game(gameLayout);
            var actual = sut.GetStatus();
            Assert.Equal(expectedGameStatus, actual);
        }
    }
}
