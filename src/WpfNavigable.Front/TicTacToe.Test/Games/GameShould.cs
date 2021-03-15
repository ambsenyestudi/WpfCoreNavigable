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
        /*
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
        */
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
        public void Tell_winne_When_Three_In_A_Row_Horizontal(GameStatus expectedGameStatus, string gameLayout)
        {
            var sut = new Game(gameLayout);
            var actual = sut.GetStatus();
            Assert.Equal(expectedGameStatus, actual);
        }
        /*
        [Theory]
        [InlineData(
            "X,O,X," +
            "X,O,O" +
            "X,,")]
        [InlineData(
            "O,," +
            "X,X,X," +
            "O,,")]
        [InlineData(
            "O,," +
            "O,," +
            "X,X,X,")]
        public void Tell_winne_When_Three_In_A_Row_Vertial(string gameLayout)
        {
            var expectedGameStatus = GameStatus.XWon;
            var sut = new Game(gameLayout);
            var actual = sut.GetStatus();
            Assert.Equal(expectedGameStatus, actual);
        }
        */
    }
}
