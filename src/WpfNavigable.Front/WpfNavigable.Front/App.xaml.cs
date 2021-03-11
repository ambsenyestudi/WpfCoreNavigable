using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfNavigable.Front.ViewModels;
using WpfNavigable.Front.Views;

namespace WpfNavigable.Front
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            INavigable[] views = new INavigable[]
            {
                new WelcomeView(new WelcomeViewModel())
            };
            var mainWindow = new MainWindow(new MainViewModel(views));
            mainWindow.Show();
        }
    }
}
