namespace TicTacToe.Domain
{
    public enum EventType
    {
        None, GameCreated
    }
    public abstract class DomainEvent
    {
        public EventType Type { get; }
        public DomainEvent(EventType type)
        {
            Type = type;
        }
    }
}
