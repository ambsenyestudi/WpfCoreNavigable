using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Application.Games;
using TicTacToe.Domain;
using TicTacToe.Front.Notifications;

namespace TicTacToe.Front.Handlers
{
    public class ChipPlayedHandler : INotificationHandler<ChipPlayed>
    {

        private readonly IPageHost pageHost;
        private readonly IGameService gameService;

        public ChipPlayedHandler(IGameService gameService, IPageHost pageHost)
        {
            this.pageHost = pageHost;
            this.gameService = gameService;
        }



        public async Task Handle(ChipPlayed notification, CancellationToken cancellationToken)
        {
            try
            {
                await gameService.PlayAsync(notification.GameId, notification.Row, notification.Column);
            }
            catch (GameNotFoundException gnfEx)
            {
                //Improve this
                pageHost.SetPage("WelcomeViewModel");
            }
        }
    }
}
