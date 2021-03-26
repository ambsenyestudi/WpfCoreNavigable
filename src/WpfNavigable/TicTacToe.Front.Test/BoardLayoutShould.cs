using TicTacToe.Front.Models;
using Xunit;

namespace TicTacToe.Front.Test
{
    public class BoardLayoutShould
    {
        [Fact]
        public void ReflectPlayedChip()
        {
            var chip = "X";
            var playedBoardLayout = TicTacToeBoardLayout.Empty.AddChip(0, 0, chip);
            Assert.True(playedBoardLayout.Count(chip) > 0);
        }

        [Fact]
        public void BeCreatedWhenCorrectFormat()
        {
            Assert.True(TicTacToeBoardLayout.TryParse(",,,,,,,,", out TicTacToeBoardLayout boardLayout));
        }
        [Fact]
        public void NotCreatWhenIncorrectFormat()
        {
            Assert.False(TicTacToeBoardLayout.TryParse(",,,", out TicTacToeBoardLayout boardLayout));
        }
    }
}
