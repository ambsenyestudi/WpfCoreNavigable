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
        public ICommand StartGameCommand { get; }
        
        public WelcomeViewModel(IMediator mediator)
        {
            this.mediator = mediator;
            StartGameCommand = new RelayCommand(StartGame);
        }

        private void StartGame(object args)
        {
            mediator.Publish(new GameStarted());
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
