using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Front.Notifications;

namespace TicTacToe.Front.Handlers
{
    public class NavigatedHandler : INotificationHandler<Navigated>
    {
        /*
        private readonly MainViewModel navigationHost;
        public Dispatcher Dispatcher { get; }

        public NavigatedHandler(MainViewModel mainViewModel)
        {
            navigationHost = mainViewModel;
            Dispatcher = Dispatcher.CurrentDispatcher;
        }
        */
        public Task Handle(Navigated notification, CancellationToken cancellationToken)
        {
            return Task.Delay(1);
            /*
            Task.Factory.StartNew(() =>
                Dispatcher.Invoke(() =>
                    navigationHost.CurrentView = notification.ViewName,
                    DispatcherPriority.Background,
                    cancellationToken));
            */
        }

        //(DispatcherPriority.Background, new DispathcerDelegate (Navigated)delegate));

    }
}
