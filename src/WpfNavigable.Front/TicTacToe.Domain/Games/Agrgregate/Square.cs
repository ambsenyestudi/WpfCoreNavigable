namespace TicTacToe.Domain.Games.Agrgregate
{
    internal record Square
    {
        public static Square Empty { get; } = new Square("");
        
        public const string X = "X";
        public const string O = "O";
        public string Value { get; }
        
        private Square(string value) => (Value) = (value);

        public static Square CreateX() =>
            new Square(X);
        public static Square CreateO() =>
            new Square(O);

    }
}
