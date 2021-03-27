using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Application.DTO;
using TicTacToe.Application.Games;
using TicTacToe.Front.Queries;

namespace TicTacToe.Front.Handlers.Queries
{
    public class BoardQueryHandler : IRequestHandler<GameSnapshotQuery, GameSnapshotDTO>
    {
        private IGameService gameService;

        public BoardQueryHandler(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public Task<GameSnapshotDTO> Handle(GameSnapshotQuery request, CancellationToken cancellationToken) =>
            gameService.GetGameSnapshotAsync(request.GameId);
    }
}
