using System;
using System.Threading.Tasks;
using TicTacToe.Application.DTO;
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

        public async Task<GameSnapshotDTO> GetGameSnapshotAsync(Guid gameIdRaw)
        {
            var boardSnapshot = await GetBoardLayout(gameIdRaw);
            return new GameSnapshotDTO
            {
                Id = gameIdRaw,
                BoardSnapshot = boardSnapshot
            };
        }

        public async Task<GameStatusDTO> GetGameStatus(Guid gameId)
        {
            var currentGame = await GetGameFrom(gameId);
            var boardState = currentGame.GetStatus();
            if(!Enum.TryParse<GameStatus>(boardState.ToString(), out GameStatus gameStatus))
            {
                return new GameStatusDTO 
                { 
                    Status = GameStatus.None, 
                    DisplayName = boardState.DisplayName
                };
            }
            return new GameStatusDTO 
            { 
                Status = gameStatus,
                DisplayName = boardState.DisplayName
            };
        }

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
