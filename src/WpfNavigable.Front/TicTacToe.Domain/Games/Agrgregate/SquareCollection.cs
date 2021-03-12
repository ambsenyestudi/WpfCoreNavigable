using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Domain.Games.Agrgregate
{
    internal class SquareCollection
    {
        public const int DIMENSION = 3;
        private readonly List<Square> itemList;
        public int FullPositionCount 
        {
            get => itemList
                .Where(x => x != Square.Empty)
                .Count();
        }
        internal SquareCollection()
        {
            itemList = new List<Square> 
            { 
                Square.Empty, Square.Empty, Square.Empty, 
                Square.Empty, Square.Empty, Square.Empty, 
                Square.Empty, Square.Empty, Square.Empty,
            };
        }

        public override string ToString() => 
            string.Join(",", itemList);

        internal void Add(int row, int column, Square square)
        {
            var index = ToListIndex(row, column);
            if (itemList[index]!=Square.Empty)
            {
                throw new PostionAlreadyPlayedException($"Cannot play position {row}, {column} because it was already full");
            }
            itemList[index] = square;

        }

        private int ToListIndex(int row, int column) =>
            row * DIMENSION + column;
    }
}
