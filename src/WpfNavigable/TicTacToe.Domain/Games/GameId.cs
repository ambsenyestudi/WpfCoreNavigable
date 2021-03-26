using System;

namespace TicTacToe.Domain
{
    public record GameId
    {
        public static GameId Empty { get; } = new GameId(Guid.Empty);

        public Guid Value { get; private set; }
        private GameId(Guid id) => (Value) = (id);
        
        public static GameId Create(Guid id)
        {
            //test of creatomg new Guid("")==Guid.Empty
            if(id == default(Guid) || id == Guid.Empty)
            {
                return Empty;
            }
            return new GameId(id);
        }

        public override string ToString() => Value.ToString();

    }
}
