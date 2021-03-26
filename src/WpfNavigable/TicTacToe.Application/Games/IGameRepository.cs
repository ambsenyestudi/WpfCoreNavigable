using System.Threading.Tasks;
using TicTacToe.Domain;
using TicTacToe.Domain.Games.Agrgregate;

namespace TicTacToe.Application.Games
{
    public interface IGameRepository
    {
        Task<string> GetBoardLayout(GameId id);
        Task<Game> GetGame(GameId id);

        Task<GameId> SaveGame(Game game);
        Task<GameId> CreateGame(Game game);

    }
}
