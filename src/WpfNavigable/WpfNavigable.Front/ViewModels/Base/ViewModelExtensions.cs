using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;
using WpfNavigable.Front.Views.Navigations.Base;

namespace WpfNavigable.Front.ViewModels.Base
{
    public static class ViewModelExtensions
    {
        public static IServiceCollection AddViewModel<TView,TViewModel>(this IServiceCollection services) where TViewModel : class where TView: Page
        {
            services.AddSingleton<TViewModel>();

            services.AddSingleton(provider =>
            {
                var vm = provider.GetRequiredService<TViewModel>();
                var page = (Page)Activator.CreateInstance(typeof(TView));
                return new NavigablePage(page, vm);
            });
            return services;
        }

    }
}
