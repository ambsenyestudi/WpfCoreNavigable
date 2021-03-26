using MediatR;

namespace WpfNavigable.Front.Notifications
{
    public class Navigated : INotification
    {
        public string ViewName { get; }
        public Navigated(string viewName)
        {
            ViewName = viewName;
        }

    }

}
