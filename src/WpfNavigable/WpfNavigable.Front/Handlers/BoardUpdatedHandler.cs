using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using TicTacToe.Infrastructure.Games;
using WpfNavigable.Front.ViewModels;

namespace WpfNavigable.Front.Handlers
{
    public class BoardUpdatedHandler : INotificationHandler<BoardUpdated>
    {
        private readonly GameViewModel viewModel;
        public Dispatcher Dispatcher { get; }
        public BoardUpdatedHandler(GameViewModel viewModel)
        {
            this.viewModel = viewModel;
            Dispatcher = Dispatcher.CurrentDispatcher;
        }
        public Task Handle(BoardUpdated notification, CancellationToken cancellationToken) =>
            UpdateViewModel(notification.BoardLayout, cancellationToken);

        private Task UpdateViewModel(string boardLayout, CancellationToken cancellationToken) =>
            Task.Factory.StartNew(() => 
                Dispatcher.Invoke(()=>
                {
                    var chiplist = boardLayout.Split(',');
                    if (!string.IsNullOrWhiteSpace(chiplist[0]))
                    {
                        viewModel.TL = chiplist[0];
                    }
                    if (!string.IsNullOrWhiteSpace(chiplist[1]))
                    {
                        viewModel.TC = chiplist[1];
                    }
                },
                    DispatcherPriority.Background,
                    cancellationToken));

        
    }
}
