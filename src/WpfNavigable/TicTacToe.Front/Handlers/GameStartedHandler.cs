using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Application.Games;
using TicTacToe.Front.Notifications;

namespace TicTacToe.Front.Handlers
{
    public class GameStartedHandler : INotificationHandler<GameStarted>
    {
        private readonly IGameService gameService;
        private readonly IGameHost gameHost;
        public GameStartedHandler(IGameService gameService, IGameHost gameHost)
        {
            
            this.gameHost = gameHost;
            this.gameService = gameService;
        }



        public async Task Handle(GameStarted notification, CancellationToken cancellationToken)
        {
            var gameId = await gameService.CreateGameAsync();
            gameHost.SetGameId(gameId.Value);
        }
    }
}
