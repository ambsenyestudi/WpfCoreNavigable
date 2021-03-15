using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Domain.Games.Agrgregate
{
    internal class SquareCollection
    {
        
        private readonly List<Square> itemList;

        public Square this [ListIndex i]
        {
            get => itemList[i.Value];
            internal set => itemList[i.Value] = value;
        }
        public int FullPositionCount 
        {
            get => itemList
                .Where(x => x != Square.Empty)
                .Count();
        }
        internal SquareCollection()
        {
            itemList = new List<Square>();
        }
        internal SquareCollection(List<Square> squareList)
        {
            itemList = squareList;
        }
        static internal SquareCollection InitalizeEmpty(int count)
        {
            var result = new SquareCollection();
            for (int i = 0; i < count; i++)
            {
                result.itemList.Add(Square.Empty);
            }
            return result;
        }
        internal void Add(ListIndex index, Square square) =>
            itemList.Add(square);
        
        internal BoardLine LineFromLineRange(ListIndexRange indexRange) =>
            indexRange.Count != Board.DIMENSION
                ? throw new InvalidOperationException("")
                : new BoardLine(
                    this[indexRange.Range.First()],
                    this[indexRange.Range[1]],
                    this[indexRange.Range.Last()]);


        public override string ToString() => 
            string.Join(",", itemList);
                
    }
}
