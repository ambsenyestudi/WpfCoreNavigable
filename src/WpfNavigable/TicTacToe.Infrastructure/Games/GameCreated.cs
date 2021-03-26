using MediatR;
using TicTacToe.Domain;

namespace TicTacToe.Infrastructure.Games
{
    public class GameCreated: INotification
    {
        public GameId GameId { get; }
        public GameCreated(GameId gameId) 
        {
            GameId = gameId;
        }
    }
}
