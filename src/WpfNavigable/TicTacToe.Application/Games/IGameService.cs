using System;
using System.Threading.Tasks;
using TicTacToe.Domain;

namespace TicTacToe.Application.Games
{
    public interface IGameService
    {
        Task<GameId> CreateGameAsync();
        Task PlayAsync(Guid gameId, int row, int column);
        Task<string> GetBoradLayoutAsync(Guid gameId);
    }
}
