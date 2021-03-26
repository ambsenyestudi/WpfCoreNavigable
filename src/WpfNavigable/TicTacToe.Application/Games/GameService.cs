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
            var storedGame = await CreateGameAsync(Guid.NewGuid());
            return storedGame.Id;
        }

        public async Task PlayAsync(Guid gameId, int row, int column)
        {
            var currGame = await CreateIfNotExists(gameId);
            var boardColumnRow = BoardRowColumn.Create(0, 0);
            currGame.Play(boardColumnRow);
            await repository.SaveGame(currGame);
        }

        private Task<Game> CreateIfNotExists(Guid id)
        {
            try
            {
                return GetFromGame(id);
            }
            catch(GameNotFoundException gnfEx)
            {
                return CreateGameAsync(id);
            }
        }

        private Task<Game> GetFromGame(Guid id) =>
            repository.GetGame(GameId.Create(id));
        private Task<Game> CreateGameAsync(Guid id) =>
            CreateGameAsync(GameId.Create(id));


        private async Task<Game> CreateGameAsync(GameId gameId)
        {
            if(gameId == GameId.Empty)
            {
                gameId = GameId.Create(Guid.NewGuid());
            }
            var game = new Game(gameId);
            var storedGameId = await repository.CreateGame(game);
            return await repository.GetGame(storedGameId);
        }
    }
}
