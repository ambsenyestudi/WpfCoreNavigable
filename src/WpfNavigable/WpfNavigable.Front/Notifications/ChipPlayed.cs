using MediatR;
using System;

namespace WpfNavigable.Front.Notifications
{
    public class ChipPlayed: INotification
    {

        public int Column { get; }
        public int Row { get; }
        public Guid GameId { get; }

        public ChipPlayed(Guid gameId, int row, int column)
        {
            Column = column;
            Row = row;
            GameId = gameId;
        }

        
    }
}
