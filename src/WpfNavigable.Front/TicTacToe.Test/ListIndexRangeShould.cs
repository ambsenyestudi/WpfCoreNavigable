using System;
using TicTacToe.Domain;
using Xunit;

namespace TicTacToe.Test
{
    public class ListIndexRangeShould
    {
        [Fact]
        public void NotBeEmpty()
        {
            Assert.Throws<InvalidOperationException>(()=> new ListIndexRange(0, 0));
        }
    }
}
