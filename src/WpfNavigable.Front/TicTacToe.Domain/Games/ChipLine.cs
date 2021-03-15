namespace TicTacToe.Domain.Games
{
    public record ChipLine
    {
        public static ChipLine Empty { get; } = new ChipLine(ChipTypes.None, ChipTypes.None, ChipTypes.None);
        private ChipTypes First { get; }
        private ChipTypes Second { get; }
        private ChipTypes Third { get; }

        public ChipLine(ChipTypes first, ChipTypes second, ChipTypes third) => (First, Second, Third) = (first, second, third);

        public bool IsFull() => this != Empty;


        public bool GetAllSame() =>
            First == Second && Second == Third;
        

    }
}
