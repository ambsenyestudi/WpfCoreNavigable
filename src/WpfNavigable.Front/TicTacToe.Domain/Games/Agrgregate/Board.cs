using System;

namespace TicTacToe.Domain.Games.Agrgregate
{
    internal class Board
    {
        public const int DIMENSION = 3;
        private readonly SquareCollection squareCollection;
        private Winner winner;
        public Board()
        {
            squareCollection = SquareCollection.InitalizeEmpty( DIMENSION * DIMENSION);
            
        }

        public string Play(ListIndex index)
        {
            if (squareCollection[index] != Square.Empty)
            {
                var pos = index.ToBoardRowColumn();
                throw new PostionAlreadyPlayedException($"Cannot play position {pos.Row}, {pos.Column} because it was already full");
            }
            var nextSquare = NextSquare();
            squareCollection[index] = nextSquare;
            winner = EvaluateWinner();
            return nextSquare.Value;
        }

        public string Play(BoardRowColumn rowColumn) =>
            Play(rowColumn.ToListIndex());
        public override string ToString() =>
            squareCollection.ToString();

        public Winner GetWinner() => winner;

        private Square NextSquare() =>
            squareCollection.FullPositionCount % 2 == 0
                ? new Square(ChipTypes.X)
                : new Square(ChipTypes.O);

        private Winner EvaluateWinner()
        {
            return EvaluateHorizontalLines();
        }

        private Winner EvaluateHorizontalLines()
        {
            var winner = Winner.None;
            var count = 0;
            while(!winner.IsWinner() && count<DIMENSION)
            {
                var offset = DIMENSION * count;
                winner = squareCollection
                    .LineFromLineRange(new ListIndexRange(offset, 3))
                    .GetWinner();
                count++;
            }
            return winner;
        }
    }
}
