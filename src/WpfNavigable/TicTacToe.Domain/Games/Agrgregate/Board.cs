namespace TicTacToe.Domain.Games.Agrgregate
{
    internal class Board
    {
        public const int DIMENSION = 3;
        private readonly SquareCollection squareCollection;
        private MatchResult winner;
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

        public MatchResult GetWinner() => winner;

        public bool IsFull() => squareCollection.FullPositionCount == DIMENSION * DIMENSION;

        private Square NextSquare() =>
            squareCollection.FullPositionCount % 2 == 0
                ? new Square(ChipTypes.X)
                : new Square(ChipTypes.O);

        private MatchResult EvaluateWinner()
        {
            var rowMatchResult = EvaluateRows();
            if (rowMatchResult.IsWinner())
            {
                return rowMatchResult;
            }
            var columnMatchResult = EvaluateColumns();
            if(columnMatchResult.IsWinner())
            {
                return columnMatchResult;
            }
            var diagonalMatchResult = EvaluateDiagonals();
            return diagonalMatchResult;
        }

        private MatchResult EvaluateRows() =>
            FindeWinningLine(
                new ListIndexRange(0, 3),
                new ListIndexRange(DIMENSION, 3),
                new ListIndexRange(DIMENSION * 2, 3));
        
        private MatchResult EvaluateColumns()
        {
            var winner = MatchResult.None;
            var count = 0;
            while (!winner.IsWinner() && count < DIMENSION)
            {
                var lineRange = FigureVerticalRange(count);
                winner = EvaluateLine(lineRange);
                count++;
            }
            return winner;
        }
        private MatchResult EvaluateDiagonals()
        {
            var leftDiagonalResult = EvaluateLine(new ListIndexRange(new int[] { 0, 4, 8 }));
            if(leftDiagonalResult.IsWinner())
            {
                return leftDiagonalResult;
            }
            
            var rightDiagonalRange = EvaluateLine(new ListIndexRange(new int[] { 2, 4, 6 }));

            return rightDiagonalRange;
        }

        private ListIndexRange FigureVerticalRange(int offset)
        {
            var verticalIdexes = new int[3];
            var count = 0;
            while(count < verticalIdexes.Length)
            {
                var currIndex = count *  DIMENSION +offset;
                verticalIdexes[count] = currIndex;
                count++;
            }
            return new ListIndexRange(verticalIdexes);
        }

        private MatchResult FindeWinningLine(params ListIndexRange[] rangeList)
        {
            var winner = MatchResult.None;
            var count = 0;
            while (!winner.IsWinner() && count < DIMENSION)
            {
                winner = EvaluateLine(rangeList[count]);
                count++;
            }
            return winner;
        }
        private MatchResult EvaluateLine(ListIndexRange indexRange)
        {
            var line = squareCollection.LineFromLineRange(indexRange);
            return line.GetWinner();
        }
    }
}
