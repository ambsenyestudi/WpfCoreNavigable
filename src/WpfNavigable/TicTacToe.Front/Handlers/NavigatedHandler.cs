using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Front.Notifications;

namespace TicTacToe.Front.Handlers
{
    public class NavigatedHandler : INotificationHandler<Navigated>
    {
        private readonly IPageHost pageHost;

        public NavigatedHandler(IPageHost pageHost)
        {
            this.pageHost = pageHost;
        }
        public Task Handle(Navigated notification, CancellationToken cancellationToken) =>
            Task.Factory.StartNew(() => pageHost.SetPage(notification.ViewName));

    }
}
