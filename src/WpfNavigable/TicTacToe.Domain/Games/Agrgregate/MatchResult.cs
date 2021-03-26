namespace TicTacToe.Domain.Games.Agrgregate
{
    public record MatchResult
    {
        public static MatchResult None { get; } = new MatchResult(ChipTypes.None);

        public ChipTypes Winner { get; }
        
        public MatchResult(ChipTypes chip) => (Winner) = (chip);

        public bool IsWinner() => Winner != ChipTypes.None;
    }
}
