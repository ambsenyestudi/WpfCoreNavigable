using System;
using System.Threading.Tasks;
using TicTacToe.Application.DTO;
using TicTacToe.Domain;

namespace TicTacToe.Application.Games
{
    public interface IGameService
    {
        Task<GameId> CreateGameAsync();
        Task PlayAsync(Guid gameId, int row, int column);
        Task<GameSnapshotDTO> GetGameSnapshotAsync(Guid gameId);
        Task<GameStatusDTO> GetGameStatus(Guid gameId);
    }
}
