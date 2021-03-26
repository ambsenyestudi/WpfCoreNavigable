using System.Threading.Tasks;
using TicTacToe.Domain;
using TicTacToe.Domain.Games.Agrgregate;

namespace TicTacToe.Application.Games
{
    public interface IGameRepository
    {
        Task<Game> GetGame(GameId gameId);

        Task<GameId> SaveGame(Game game);
        Task<GameId> CreateGame(Game game);

    }
}
