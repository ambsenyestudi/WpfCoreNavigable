using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicTacToe.Application.Games;
using TicTacToe.Front;
using TicTacToe.Infrastructure.Games;
using WpfNavigable.Front.ViewModels;
using WpfNavigable.Front.Views;

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
            services.Configure<PathServiceSettings>(settings => Configuration.GetSection(nameof(PathServiceSettings)).Bind(settings));
            services.Configure<CourseSettings>(settings => Configuration.GetSection(nameof(CourseSettings)).Bind(settings));
            services.Configure<LessonSettings>(settings => Configuration.GetSection(nameof(LessonSettings)).Bind(settings));
            
            services.AddHttpClient<PathService>();
            services.AddScoped<IPathService, PathCacheDecorator>(provider =>
                new PathCacheDecorator(
                    provider.GetService<PathService>(),
                    provider.GetService<IMemoryCache>()));
            services.AddSingleton<ITextService, TextService>();
            */
            services.AddSingleton<IGameService, GameService>();
            services.AddSingleton<IGameRepository, InMemoryGamesRepository>();
            services.AddSingleton<GameViewModel>()
                .AddSingleton<IGameHost>( provider =>
                    provider.GetRequiredService<GameViewModel>());
            services.AddSingleton<INavigable, GameView>();
            services.AddSingleton<WelcomeViewModel>();
            services.AddSingleton<INavigable, WelcomeView>();
            services.AddSingleton<MainViewModel>()
                .AddSingleton<IPageHost>(provider => 
                    provider.GetRequiredService<MainViewModel>());
            services.AddSingleton<MainWindow>();
            services.AddMediatR(Assembly.GetAssembly(typeof(IPageHost)));
            //services.AddMemoryCache();
        }
        public void Configure(ApplicationBuilder application)
        {
            //Todo
        }
    }
}
