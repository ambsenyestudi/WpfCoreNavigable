using System;

namespace TicTacToe.Domain.Games.Agrgregate
{
    internal record SquareLine
    {
        internal Square First { get; }
        internal Square Second { get; }
        internal Square Third { get; }

        internal SquareLine(Square first, Square second, Square third) => (First, Second, Third) = (first, second, third);

        internal MatchResult GetWinner()
        {
            var chipLine = ToChipLine();
            if (!chipLine.IsFull() || !chipLine.GetAllSame())
            {
                return MatchResult.None;
            }
            var winningChip = Enum.Parse<ChipTypes>(First.Value);
            return new MatchResult(winningChip);
        }
        internal ChipLine ToChipLine() =>
            new ChipLine(
                First.ToChipType(),
                Second.ToChipType(),
                Third.ToChipType());

    }
}
