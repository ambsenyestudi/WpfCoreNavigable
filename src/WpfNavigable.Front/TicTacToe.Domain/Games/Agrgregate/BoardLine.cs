using System;

namespace TicTacToe.Domain.Games.Agrgregate
{
    internal record BoardLine
    {
        internal Square First { get; }
        internal Square Second { get; }
        internal Square Third { get; }

        internal BoardLine(Square first, Square second, Square third) => (First, Second, Third) = (first, second, third);

        internal Winner GetWinner()
        {
            if(First == Square.Empty)
            {
                return Winner.None;
            }
            if(First != Second || Second != Third)
            {
                return Winner.None;
            }
            var winningChip = Enum.Parse<ChipTypes>(First.Value);
            return new Winner(winningChip);
        }

    }
}
