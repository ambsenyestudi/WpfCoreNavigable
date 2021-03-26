using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using TicTacToe.Application.Games;
using TicTacToe.Domain;
using WpfNavigable.Front.Notifications;
using WpfNavigable.Front.ViewModels;
using WpfNavigable.Front.Views;

namespace WpfNavigable.Front.Handlers
{
    public class ChipPlayedHandler : INotificationHandler<ChipPlayed>
    {
        public Dispatcher Dispatcher { get; }

        private readonly MainViewModel navigationHost;
        private readonly IGameService gameService;

        public ChipPlayedHandler(IGameService gameService, MainViewModel mainViewModel )
        {
            Dispatcher = Dispatcher.CurrentDispatcher;
            this.navigationHost = mainViewModel;
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
                Dispatcher.Invoke(() =>
                    navigationHost.CurrentView = nameof(WelcomeView),
                    DispatcherPriority.Background,
                    cancellationToken);
            }
        }
    }
}
