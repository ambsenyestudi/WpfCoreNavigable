using System;

namespace TicTacToe.Domain.Games
{
    public class PostionAlreadyPlayedException:Exception
    {
        public PostionAlreadyPlayedException(string message):base(message)
        {
        }
    }
}
