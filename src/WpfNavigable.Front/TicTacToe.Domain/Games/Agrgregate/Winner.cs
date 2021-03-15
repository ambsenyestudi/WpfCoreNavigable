namespace TicTacToe.Domain.Games.Agrgregate
{
    public record Winner
    {
        public static Winner None { get; } = new Winner(ChipTypes.None);

        public ChipTypes Value { get; }
        
        public Winner(ChipTypes chip) => (Value) = (chip);

        public bool IsWinner() => Value != ChipTypes.None;
    }
}
