using System;

namespace TicTacToe.Front
{
    public interface IGameHost
    {
        void Reset();
        void SetGameId(Guid id);
    }
}
