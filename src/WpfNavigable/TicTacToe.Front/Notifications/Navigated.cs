using MediatR;

namespace TicTacToe.Front.Notifications
{
    public class Navigated : INotification
    {
        public string ViewModelName { get; }
        public Navigated(string viewModelName)
        {
            ViewModelName = viewModelName;
        }

    }
}
