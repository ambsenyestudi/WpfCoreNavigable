using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Application.DTO;
using TicTacToe.Application.Games;
using TicTacToe.Front.Queries;

namespace TicTacToe.Front.Handlers.Queries
{
    public class GameStatusQueryHandler : IRequestHandler<GameStatusQuery, GameStatusDTO>
    {
        private IGameService gameService;

        public GameStatusQueryHandler(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public Task<GameStatusDTO> Handle(GameStatusQuery request, CancellationToken cancellationToken) =>
            gameService.GetGameStatus(request.GameId);
    }
}
