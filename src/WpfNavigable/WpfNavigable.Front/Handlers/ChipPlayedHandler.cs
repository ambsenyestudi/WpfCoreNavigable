using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Application.Games;
using WpfNavigable.Front.Notifications;

namespace WpfNavigable.Front.Handlers
{
    public class ChipPlayedHandler : INotificationHandler<ChipPlayed>
    {
        private readonly IGameService gameService;

        public ChipPlayedHandler(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public Task Handle(ChipPlayed notification, CancellationToken cancellationToken)
        {
           return gameService.PlayAsync(notification.GameId, notification.Row, notification.Column);
        }
    }
}
