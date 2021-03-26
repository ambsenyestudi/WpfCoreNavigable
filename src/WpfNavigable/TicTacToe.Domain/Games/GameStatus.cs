namespace TicTacToe.Domain.Games
{
    public class GameStatus: TicTacToeEnumeration
    {
        
        public static GameStatus None { get; } = new GameStatus(0, nameof(None));
        public static GameStatus Playing { get; } = new GameStatus(1, nameof(Playing));
        public static GameStatus XWon { get; } = new GameStatus(2, nameof(XWon), "X wins current game");
        public static GameStatus OWon { get; } = new GameStatus(3, nameof(OWon), "O wins current game");
        public static GameStatus Draw { get; } = new GameStatus(4, nameof(Draw), "Game ended in draw");

        public string DisplayName { get; }
        private GameStatus(int id, string name, string displayName = ""):base(id, name)
        {
            if(string.IsNullOrWhiteSpace(displayName))
            {
                displayName = name;
            }
            DisplayName = displayName;
        }

        public static bool TryParse(string input, out GameStatus gamestatus)
        {
            if(IsSameAs(input, nameof(None)))
            {
                gamestatus = None;
                return true;
            }
            if (IsSameAs(input, nameof(Playing)))
            {
                gamestatus = Playing;
                return true;
            }
            if (IsSameAs(input, nameof(XWon)))
            {
                gamestatus = XWon;
                return true;
            }
            if (IsSameAs(input, nameof(OWon)))
            {
                gamestatus = OWon;
                return true;
            }
            if (IsSameAs(input, nameof(Draw)))
            {
                gamestatus = Draw;
                return true;
            }
            gamestatus = null;
            return false;
        }
        public static bool IsSameAs(string input, string enumName) =>
            input.ToUpper() == enumName.ToUpper();
    }
}
