using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Application.Games;
using TicTacToe.Domain;
using TicTacToe.Front.Handlers;
using TicTacToe.Front.Notifications;
using Xunit;

namespace TicTacToe.Front.Test
{
    public class ChipPlayerHandlerShould
    {
        private readonly IGameService gameService;
        private readonly IPageHost pageHost;
        private readonly ChipPlayedHandler sut;
        private readonly Guid GAME_ID = new Guid("4be8ec6c-7560-43f1-8387-ed0c92f57f74");
        private readonly Guid NON_EXISTANT_GAME_ID = new Guid("395e79f6-6dc0-4d32-84f5-25ccc5de2887");
        public ChipPlayerHandlerShould()
        {
            gameService = Substitute.For<IGameService>();
            pageHost = Substitute.For<IPageHost>();
            sut = new ChipPlayedHandler(gameService, pageHost);
        }

        [Fact]
        public async Task NotPlayOnUnidentifiedGame()
        {
            var chipPlayed = new ChipPlayed(Guid.Empty, 0, 0);
            await sut.Handle(chipPlayed, CancellationToken.None);
            gameService.DidNotReceiveWithAnyArgs().PlayAsync(default, default, default);
        }

        [Fact]
        public async Task NotPlayWhenNegativeRow()
        {
            var negativeRow = -1;
            var column = 0;
            var chipPlayed = new ChipPlayed(GAME_ID, negativeRow, column);
            await sut.Handle(chipPlayed, CancellationToken.None);
            gameService.DidNotReceiveWithAnyArgs().PlayAsync(default, default, default);
        }
        [Fact]
        public async Task NotPlayWhenNegativeColumn()
        {
            var row = 0;
            var negativeColumn = -1;
            var chipPlayed = new ChipPlayed(GAME_ID, row, negativeColumn);
            await sut.Handle(chipPlayed, CancellationToken.None);
            gameService.DidNotReceiveWithAnyArgs().PlayAsync(default, default, default);
        }
        [Fact]
        public async Task NotPlayWhenRowBiggerThanAllowed()
        {
            var biggerThanAllowerdRow = 3;
            var column = 0;
            var chipPlayed = new ChipPlayed(GAME_ID, biggerThanAllowerdRow, column);
            await sut.Handle(chipPlayed, CancellationToken.None);
            gameService.DidNotReceiveWithAnyArgs().PlayAsync(default, default, default);
        }
        [Fact]
        public async Task NotPlayWhenColumnBiggerThanAllowed()
        {
            var row = 0;
            var biggerThanAllowerdColumn = 3;
            var chipPlayed = new ChipPlayed(GAME_ID, row, biggerThanAllowerdColumn);
            await sut.Handle(chipPlayed, CancellationToken.None);
            gameService.DidNotReceiveWithAnyArgs().PlayAsync(default, default, default);
        }
        [Fact]
        public async Task ShouldNavigateBackWhenGameNotFound()
        {
            var chipPlayed = new ChipPlayed(NON_EXISTANT_GAME_ID, 0, 0);
            gameService
                .When(x => x.PlayAsync(Arg.Any<Guid>(), 0, 0))
                .Do(x => throw new GameNotFoundException(GameId.Empty));
            await sut.Handle(chipPlayed, CancellationToken.None);
            pageHost.ReceivedWithAnyArgs().SetPage(default);
        }
    }
}
