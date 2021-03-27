using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Application.Games;
using TicTacToe.Front.Notifications;

namespace TicTacToe.Front.Handlers
{
    public class GameStartedHandler : INotificationHandler<GameStarted>
    {
        private readonly IGameService gameService;
        /*
        public Dispatcher Dispatcher { get; }

        private readonly GameViewModel viewModel;
        */
        public GameStartedHandler(IGameService gameService)//, GameViewModel viewModel)
        {
            /*
            Dispatcher = Dispatcher.CurrentDispatcher;
            this.viewModel = viewModel;
            */
            this.gameService = gameService;
        }



        public async Task Handle(GameStarted notification, CancellationToken cancellationToken)
        {
            var gameId = await gameService.CreateGameAsync();
            //Todo
            /*
            Dispatcher.Invoke(() => viewModel.Reset(gameId.Value),
                    DispatcherPriority.Background,
                    cancellationToken);
            */
        }
    }
}
