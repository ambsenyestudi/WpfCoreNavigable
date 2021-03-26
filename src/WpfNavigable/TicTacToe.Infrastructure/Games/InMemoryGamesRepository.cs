using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Application.Games;
using TicTacToe.Domain;
using TicTacToe.Domain.Games.Agrgregate;

namespace TicTacToe.Infrastructure.Games
{
    public class InMemoryGamesRepository : IGameRepository
    {

        private Dictionary<GameId, string> GameSnapshotDictionary { get; } = new Dictionary<GameId, string>();

        public Task<Game> GetGame(GameId id)
        {
            if (!GameSnapshotDictionary.ContainsKey(id))
            {
                throw new GameNotFoundException(id);
            }
            return Task.Factory.StartNew(() =>
            {
                var gameLayout = GameSnapshotDictionary[id];
                return new Game(id, gameLayout);
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
                return game.Id;
            });

        

        private Task UpdateGame(Game game) =>
            Task.Factory.StartNew(() => 
            {
                var boardLayout = game.ToString();
                GameSnapshotDictionary[game.Id] = boardLayout;
            });

        public Task<string> GetBoardLayout(GameId id) =>
            Task.Factory.StartNew(() => GameSnapshotDictionary[id]);
    }
}
