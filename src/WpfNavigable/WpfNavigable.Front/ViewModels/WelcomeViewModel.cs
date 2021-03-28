using MediatR;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TicTacToe.Application.Secrets;
using TicTacToe.Front.Notifications;
using WpfNavigable.Front.ViewModels.Base;

namespace WpfNavigable.Front.ViewModels
{
    public class WelcomeViewModel
    {
        private readonly ISecretsService secretsService;
        private readonly IMediator mediator;
        public ICommand StartGameCommand { get; }
        public ICommand EasternCommand { get; }


        public WelcomeViewModel(IMediator mediator, ISecretsService secretsService)
        {
            this.secretsService = secretsService;
            this.mediator = mediator;
            StartGameCommand = new RelayCommand(StartGame);
            EasternCommand = new RelayCommand(LaunchDialog);
        }

        private void StartGame(object arg)
        {
            mediator.Publish(new GameStarted());
            mediator.Publish(new Navigated(nameof(GameViewModel)));            
        }

        private void LaunchDialog(object arg)
        {
            var oldTheme = secretsService.RetriveSecretTheme();
            var message = oldTheme == SecretTheme.Light
                ? "You are about to enter the dak side"
                : "You going back to the light";
            MessageBoxResult result = MessageBox.Show(message,
              "Confirmation",
              MessageBoxButton.OK,
              MessageBoxImage.Information);
            var theme = secretsService.SwitchTheme(oldTheme);
            Application.Current.Resources["AppBackground"] = ToSolidColorBrush(theme.BackgroundColor);
            Application.Current.Resources["AppForeground"] = ToSolidColorBrush(theme.ForegroundColor);
            Application.Current.Resources["AppButtonBackground"] = ToSolidColorBrush(theme.ButtonBackgroundColor);
            
        }
        private SolidColorBrush ToSolidColorBrush(string color)
        {
            PropertyInfo propertyInfo = typeof(Colors).GetProperty(color);
            Color currColor = (Color)propertyInfo.GetValue(null, null);
            return new SolidColorBrush(currColor);
        }
    }
}
