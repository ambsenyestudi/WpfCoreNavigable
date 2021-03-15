using System;
using TicTacToe.Domain.Games;
using TicTacToe.Domain.Games.Agrgregate;

namespace TicTacToe.Domain
{
    public record ListIndex
    {
        public int Value { get; }
        private ListIndex(int value) => (Value) = (value);

        public BoardRowColumn ToBoardRowColumn() =>
            BoardRowColumn.Create(
                Value / Board.DIMENSION,
                Value % Board.DIMENSION);

        public static ListIndex Create(int index)
        {
            if(index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return new ListIndex(index);
        }
        public static bool TryParse(int index, int count, out ListIndex listIndex)
        {
            var canParse = IsValidListIndex(index, count);
            if (!canParse)
            {
                listIndex = null;
                return canParse;
            }
            listIndex = new ListIndex(index);
            return canParse;
        }
        private static bool IsValidListIndex(int index, int count) =>
            !IsEmptyCount(count) && IsInRange(index, count);

        private static bool IsInRange(int index, int count) =>
            index >= 0 && index < count;

        private static bool IsEmptyCount(int count) =>
            count == 0;


    }
}
