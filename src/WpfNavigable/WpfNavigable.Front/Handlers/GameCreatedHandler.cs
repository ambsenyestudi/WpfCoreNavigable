using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Infrastructure.Games;
using WpfNavigable.Front.ViewModels;

namespace WpfNavigable.Front.Handlers
{
    public class GameCreatedHandler : INotificationHandler<GameCreated>
    {
        private readonly GameViewModel viewModel;

        public GameCreatedHandler(GameViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public Task Handle(GameCreated notification, CancellationToken cancellationToken) =>
            Task.Factory.StartNew(() => viewModel.GameId = notification.GameId.Value);
    }
}
