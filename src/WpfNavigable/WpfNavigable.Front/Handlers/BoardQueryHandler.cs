using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Application.Games;
using WpfNavigable.Front.Queries;

namespace WpfNavigable.Front.Handlers
{
    public class BoardQueryHandler : IRequestHandler<BoardLayoutQuery, string>
    {
        private IGameService gameService;

        public BoardQueryHandler(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public Task<string> Handle(BoardLayoutQuery request, CancellationToken cancellationToken) =>
            gameService.GetBoradLayoutAsync(request.GameId);
    }
}
