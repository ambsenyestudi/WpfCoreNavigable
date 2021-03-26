using System;

namespace TicTacToe.Domain
{
    public class GameNotFoundException: Exception
    {
        public const string ERROR_TEMPLATE = "Game {0} was not present in storeage";   
        public GameNotFoundException(GameId gameId): base (string.Format(ERROR_TEMPLATE, gameId))
        {
        }
    }
}
