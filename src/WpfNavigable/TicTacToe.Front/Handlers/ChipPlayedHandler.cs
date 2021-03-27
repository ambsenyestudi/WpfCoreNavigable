using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Application.Games;
using TicTacToe.Domain;
using TicTacToe.Front.Models;
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
            if (IsValidPlay(notification))
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
        private bool IsValidPlay(ChipPlayed chipPlayed)
        {
            if(chipPlayed.GameId == Guid.Empty)
            {
                return false;
            }
            if(chipPlayed.Row < 0 || chipPlayed.Row >= TicTacToeBoardLayout.BOARD_SIZE)
            {
                return false;
            }
            if (chipPlayed.Column < 0 || chipPlayed.Column >= TicTacToeBoardLayout.BOARD_SIZE)
            {
                return false;
            }
            return true;
        }
    }
}
