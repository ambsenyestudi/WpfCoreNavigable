using MediatR;
using System;

namespace WpfNavigable.Front.Queries
{
    public class BoardLayoutQuery: IRequest<string>
    {
        public Guid GameId { get; }
        public BoardLayoutQuery(Guid gameId)
        {
            GameId = gameId;
        }

        
    }
}
