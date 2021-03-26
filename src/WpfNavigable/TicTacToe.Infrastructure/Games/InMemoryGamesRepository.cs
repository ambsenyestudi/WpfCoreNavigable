using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Application.Games;
using TicTacToe.Domain;
using TicTacToe.Domain.Games.Agrgregate;

namespace TicTacToe.Infrastructure.Games
{
    public class InMemoryGamesRepository : IGameRepository
    {
        private readonly IMediator mediator;

        private Dictionary<GameId, string> GameSnapshotDictionary { get; } = new Dictionary<GameId, string>();

        public InMemoryGamesRepository(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<Game> GetGame(GameId gameId)
        {
            if (!GameSnapshotDictionary.ContainsKey(gameId))
            {
                throw new GameNotFoundException(gameId);
            }
            return Task.Factory.StartNew(() =>
            {
                var gameLayout = GameSnapshotDictionary[gameId];
                return new Game(gameId, gameLayout);
            });

        }

        public async Task<GameId> SaveGame(Game game)
        {
            if (!GameSnapshotDictionary.ContainsKey(game.Id))
            {
                return await CreateGame(game);
            }
            await UpdateGame(game);
            return game.Id;
        }
        public Task<GameId> CreateGame(Game game) =>
            Task.Factory.StartNew(() => 
            {
                GameSnapshotDictionary.Add(game.Id, game.ToString());
                mediator.Publish(new GameCreated(game.Id));
                return game.Id;
            });

        

        private Task UpdateGame(Game game) =>
            Task.Factory.StartNew(() => 
            {
                var boardLayout = game.ToString();
                GameSnapshotDictionary[game.Id] = boardLayout;
                mediator.Publish(new BoardUpdated(boardLayout));
            });
    }
}
