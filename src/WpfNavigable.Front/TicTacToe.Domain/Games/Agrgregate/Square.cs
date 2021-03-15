using System;

namespace TicTacToe.Domain.Games.Agrgregate
{
    internal record Square
    {
        public static Square Empty { get; } = new Square(ChipTypes.None);
        
        public string Value { get; }
        
        internal Square(ChipTypes chip)
        {
            Value = ChipToString(chip);
        }

        private string ChipToString(ChipTypes chip)
        {
            if(chip==ChipTypes.None)
            {
                return string.Empty;
            }
            return chip.ToString();
        }
    }
}
