using MediatR;

namespace TicTacToe.Infrastructure.Games
{
    public class BoardUpdated : INotification
    {
        public string BoardLayout { get; }
        public BoardUpdated(string boardLayout)
        {
            BoardLayout = boardLayout;
        }
               
    }
}
