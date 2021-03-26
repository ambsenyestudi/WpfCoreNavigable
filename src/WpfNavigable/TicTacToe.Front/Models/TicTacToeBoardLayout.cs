using System.Collections.Generic;

namespace TicTacToe.Front.Models
{
    public record TicTacToeBoardLayout
    {
        public const int BOARD_SIZE = 3;
        public const int SQUARE_COUNT = 9;
        private const string SEPARATOR = ",";

        public static TicTacToeBoardLayout Empty { get; } = new TicTacToeBoardLayout(",,,,,,,,");
        public string Value { get; }
        private TicTacToeBoardLayout(string value) => (Value) = (value);

        public int Count(string chip) => CountOcurrancesOf(Value, chip);

        

        public TicTacToeBoardLayout AddChip(int row, int column, string chip)
        {
            var boardPositions = ParseSquares(Value);
            var index = PostionToIndex(row, column);
            boardPositions[index] = chip;
            return new TicTacToeBoardLayout(string.Join(",",boardPositions));
        }

        public string GetChip(int row, int column)
        {
            var boardPositions = ParseSquares(Value);
            var index = PostionToIndex(row, column);
            var result = boardPositions[index];
            return result;
        }

        public static bool TryParse(string boardlLayoutRaw, out TicTacToeBoardLayout boardLayout)
        {
            if (string.IsNullOrEmpty(boardlLayoutRaw) || !IsValidLayoutFormat(boardlLayoutRaw))
            {
                boardLayout = null;
                return false;
            }
            boardLayout = new TicTacToeBoardLayout(boardlLayoutRaw);
            return true;
        }

        private static bool IsValidLayoutFormat(string layout) =>
            CountOcurrancesOf(layout, SEPARATOR) == SQUARE_COUNT - 1;

        private static IList<string> ParseSquares(string boardLayout) =>
            boardLayout.Split(',');

        private int PostionToIndex(int row, int column) =>
            row * BOARD_SIZE + column;

        private static int CountOcurrancesOf(string boardLayout, string chip)
        {
            var occuranceCount = 0;
            var boardPostions = boardLayout.ToCharArray();
            for (int i = 0; i < boardPostions.Length; i++)
            {
                if($"{boardPostions[i]}" == chip)
                {
                    occuranceCount++;
                }
            }
            return occuranceCount;
        }

    }
}
