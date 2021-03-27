using MediatR;
using System;
using TicTacToe.Application.DTO;

namespace TicTacToe.Front.Queries
{
    public class GameStatusQuery : IRequest<GameStatusDTO>
    {
        public Guid GameId { get; }
        public GameStatusQuery(Guid id)
        {
            GameId = id;
        }
    }
}
