using Microsoft.Extensions.DependencyInjection;
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
        private ServiceProvider serviceProvider;
        public App()
        {
            serviceProvider = CreateHost().Build();
        }

        private ApplicationBuilder CreateHost() =>
            ApplicationBuilder.CreateDefaultBuilder();
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
                /*
            INavigable[] views = new INavigable[]
            {
                new WelcomeView(new WelcomeViewModel())
            };
            var mainWindow = new MainWindow(new MainViewModel(views));
            mainWindow.Show();*/
        }
    }
}
