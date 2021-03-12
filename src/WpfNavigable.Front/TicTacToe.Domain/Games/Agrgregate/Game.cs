namespace TicTacToe.Domain.Games.Agrgregate
{
    public class Game
    {
        private readonly BoardState boardState;

        public Game()
        {
            boardState = BoardState.Empty;
        }

        public BoardState GetBoardState() =>
            boardState;

        public string Play(int row, int column)
        {
            return "X";
        }
    }
}
