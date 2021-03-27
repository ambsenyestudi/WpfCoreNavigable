using MediatR;
using System;
using TicTacToe.Application.DTO;

namespace TicTacToe.Front.Queries
{
    public class GameSnapshotQuery : IRequest<GameSnapshotDTO>
    {
        public Guid GameId { get; }
        public GameSnapshotQuery(Guid gameId)
        {
            GameId = gameId;
        }


    }
}
