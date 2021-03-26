using System;
using System.Threading.Tasks;
using TicTacToe.Domain;
using TicTacToe.Domain.Games;
using TicTacToe.Domain.Games.Agrgregate;

namespace TicTacToe.Application.Games
{
    public class GameService : IGameService
    {
        private readonly IGameRepository repository;

        public GameService(IGameRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GameId> CreateGameAsync()
        {
            var storedGame = await CreateNewGameAsync();
            return storedGame.Id;
        }

        public async Task PlayAsync(Guid gameIdRaw, int row, int column)
        {
            var currGame = await GetGameFrom(gameIdRaw);
            var boardColumnRow = BoardRowColumn.Create(row, column);
            currGame.Play(boardColumnRow);
            await repository.SaveGame(currGame);
        }

        public Task<string> GetBoradLayoutAsync(Guid gameIdRaw) =>
            GetBoardLayout(gameIdRaw);

        private Task<string> GetBoardLayout(Guid gameIdRaw) =>
            repository.GetBoardLayout(GameId.Create(gameIdRaw));

        private Task<Game> GetGameFrom(Guid id) =>
            repository.GetGame(GameId.Create(id));

        private Task<Game> CreateNewGameAsync() =>
            CreateNewGameAsync(GameId.Empty);

        private async Task<Game> CreateNewGameAsync(GameId gameId)
        {
            if (gameId == GameId.Empty)
            {
                gameId = GameId.Create(Guid.NewGuid());
            }
            var game = new Game(gameId);
            var storedGameId = await repository.CreateGame(game);
            return await repository.GetGame(storedGameId);
        }
    }
}
