using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TicTacToe.Domain
{
    public record ListIndexRange
    {
        public ReadOnlyCollection<ListIndex> Range { get; }
        public int Count { get => Range.Count; }
        public ListIndexRange(params int[] items)
        {
            Range = ToListIndexCollection(items)
                .AsReadOnly();
        }
        public ListIndexRange(int start, int count)
        {   
            Range = ToListIndexCollection(start, count)
                .AsReadOnly();
        }

        private List<ListIndex> ToListIndexCollection(int[] items)
        {
            EnsureFull(items);
            return items
                .Select(it => ListIndex.Create(it))
                .ToList();
        }

        private List<ListIndex> ToListIndexCollection(int start, int count)
        {
            var indexRange = new int[count];
            for (int i = 0; i < count; i++)
            {
                indexRange[i] = start + i;
            }
            return ToListIndexCollection(indexRange);
        }

        private void EnsureFull(int[] items)
        {
            if(!items.Any())
            {
                throw new InvalidOperationException("");
            }
        }
        
            

    }
}
