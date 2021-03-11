using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
            services.AddSingleton<GameViewModel>();
            services.AddSingleton<INavigable, GameView>();
            services.AddSingleton<WelcomeViewModel>();
            services.AddSingleton<INavigable, WelcomeView>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMemoryCache();
        }
        public void Configure(ApplicationBuilder application)
        {
            //Todo
        }
    }
}
