using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Application.Games;
using TicTacToe.Domain;
using TicTacToe.Front.Notifications;

namespace TicTacToe.Front.Handlers
{
    public class ChipPlayedHandler : INotificationHandler<ChipPlayed>
    {
        /*
        public Dispatcher Dispatcher { get; }

        private readonly MainViewModel navigationHost;
        */
        private readonly IGameService gameService;

        public ChipPlayedHandler(IGameService gameService)//, MainViewModel mainViewModel)
        {
            /*
            Dispatcher = Dispatcher.CurrentDispatcher;
            this.navigationHost = mainViewModel;
            */
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
                /*
                Dispatcher.Invoke(() =>
                    navigationHost.CurrentView = nameof(WelcomeView),
                    DispatcherPriority.Background,
                    cancellationToken);
                */
            }
        }
    }
}
