using System;
using TicTacToe.Domain.Games.Agrgregate;

namespace TicTacToe.Domain.Games
{
    public record BoardRowColumn
    {
        public int Row { get; }
        public int Column { get; }
        
        private BoardRowColumn(int row, int column) => (Row, Column) = (row, column);

        public ListIndex ToListIndex() =>
            ListIndex.Create(
            Row * Board.DIMENSION + Column);

        public static BoardRowColumn Create(int row, int column)
        {
            if(row < 0 || column < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if(row >= Board.DIMENSION || column >= Board.DIMENSION)
            {
                throw new IndexOutOfRangeException();
            }
            return new BoardRowColumn(row, column);
        }
        
    }
}
