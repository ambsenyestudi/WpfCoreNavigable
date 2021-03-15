using TicTacToe.Domain.Games;
using Xunit;

namespace TicTacToe.Test.Games
{
    public class ChipLineShould
    {
        
        [Fact]
        public void TellWhenLineIsFull()
        {
            var xSquare = ChipTypes.X;
            var oSquare = ChipTypes.O;
            var sut = new ChipLine(xSquare, oSquare, xSquare);
            Assert.True(sut.IsFull());
        }
        [Fact]
        public void TellWhenLineIsNotFull()
        {
            var xSquare = ChipTypes.X;
            var oSquare = ChipTypes.O;
            var sut = new ChipLine(xSquare, oSquare, ChipTypes.None);
            Assert.True(sut.IsFull());
        }
        [Fact]
        public void TellWhenLineIsEmpty()
        {
            var sut = new ChipLine(ChipTypes.None, ChipTypes.None, ChipTypes.None);
            Assert.Equal(ChipLine.Empty, sut);
        }

    }
}
