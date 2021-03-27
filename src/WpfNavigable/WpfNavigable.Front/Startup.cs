using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicTacToe.Application.Games;
using TicTacToe.Front.Models;
using TicTacToe.Infrastructure.Games;
using WpfNavigable.Front.ViewModels;
using WpfNavigable.Front.Views;
using WpfNavigable.Front.ViewModels.Base;
namespace WpfNavigable.Front
{
    public class Startup
    {
        
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        

        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.Configure<LessonSettings>(settings => Configuration.GetSection(nameof(LessonSettings)).Bind(settings));
            services.AddHttpClient<PathService>();
            */
            services
                .AddSingleton<IGameService, GameService>()
                .AddSingleton<IGameRepository, InMemoryGamesRepository>()
                .AddViewModel<GameView, GameViewModel>()
                .AddViewModel<WelcomeView, WelcomeViewModel>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetAssembly(typeof(TicTacToeBoardLayout)));


        }
        public void Configure(ApplicationBuilder application)
        {
            //Todo
        }
    }
}
