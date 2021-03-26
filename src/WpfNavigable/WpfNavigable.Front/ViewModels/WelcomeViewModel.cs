using MediatR;
using System.Windows;
using System.Windows.Input;
using WpfNavigable.Front.Notifications;
using WpfNavigable.Front.ViewModels.Base;
using WpfNavigable.Front.Views;

namespace WpfNavigable.Front.ViewModels
{
    public class WelcomeViewModel
    {
        private readonly IMediator mediator;
        public ICommand NavigateCommand { get; }
        
        public WelcomeViewModel(IMediator mediator)
        {
            this.mediator = mediator;
            NavigateCommand = new RelayCommand(Navigate);
        }

        private void Navigate(object args)
        {
            mediator.Publish(new Navigated(nameof(GameView)));
            
        }
        private void LaunchDialog()
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close this window?",
              "Confirmation",
              MessageBoxButton.YesNo,
              MessageBoxImage.Question);
        }
    }
}
