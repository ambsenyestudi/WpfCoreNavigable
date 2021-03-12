using System;

namespace TicTacToe.Domain.Games.Agrgregate
{
    public class Game
    {
        private readonly BoardState boardState;
        private SquareCollection squareCollection;
        private GameStatus status;

        public Game(string gameLayout="")
        {
            boardState = BoardState.Empty;
            squareCollection = new SquareCollection();
            SetGameLayout(gameLayout);
            status = GameStatus.Playing;
        }

        public override string ToString() =>
            squareCollection.ToString();

        public BoardState GetBoardState() =>
            boardState;
        public GameStatus GetStatus() => 
            status;

        public string Play(int row, int column)
        {
            var nextSquare = NextSquare();
            squareCollection.Add(row, column, nextSquare);
            UpdateStatus();
            return nextSquare.Value;
        }


        private void UpdateStatus()
        {
            status = GameStatus.Playing;
        }
        private void SetGameLayout(string gameLayout)
        {
            if(!string.IsNullOrWhiteSpace(gameLayout))
            {
                var plays = gameLayout.Split(",");
                PlayLayout(plays);
            }
        }

        private void PlayLayout(string[] plays)
        {
            for (int i = 0; i < plays.Length; i++)
            {
                var nextSquare = NextSquare();
                var (row, column) = IndexToRowColumn(i);
                squareCollection.Add(row, column, nextSquare);
            }
        }
        private (int, int) IndexToRowColumn(int index)
        {
            var column = GetColumn(index);
            var row = GetRow(index);
            return (row, column);
        }
        private int GetColumn(int index) =>
            index % SquareCollection.DIMENSION;

        private int GetRow(int index) =>
            index / SquareCollection.DIMENSION;

        private Square NextSquare() =>
            squareCollection.FullPositionCount % 2 == 0
                ? Square.CreateX()
                : Square.CreateO();

    }
}
