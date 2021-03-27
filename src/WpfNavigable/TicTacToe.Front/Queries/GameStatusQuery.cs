using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
