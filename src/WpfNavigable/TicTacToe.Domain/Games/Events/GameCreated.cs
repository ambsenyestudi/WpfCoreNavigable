namespace TicTacToe.Domain.Games.Events
{
    public class GameCreated: DomainEvent
    {
        public GameId GameId { get; }
        public GameCreated(GameId gameId):base(EventType.GameCreated)
        {
            GameId = gameId;
        }

        
    }
}
