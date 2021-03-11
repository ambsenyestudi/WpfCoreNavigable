using System.Windows;
using System.Windows.Input;
using WpfNavigable.Front.ViewModels.Base;

namespace WpfNavigable.Front.ViewModels
{
    public class WelcomeViewModel
    {
        public ICommand NavigateCommand { get; }
        public WelcomeViewModel()
        {
            NavigateCommand = new RelayCommand(Navigate);
        }

        private void Navigate(object args)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close this window?",
              "Confirmation",
              MessageBoxButton.YesNo,
              MessageBoxImage.Question);
        }
    }
}
