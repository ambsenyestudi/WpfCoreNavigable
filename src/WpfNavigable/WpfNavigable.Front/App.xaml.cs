using Microsoft.Extensions.DependencyInjection;
using System.Windows;

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
        }
    }
}
