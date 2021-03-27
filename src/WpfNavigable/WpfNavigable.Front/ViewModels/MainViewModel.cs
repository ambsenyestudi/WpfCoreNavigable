using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;
using TicTacToe.Front;
using WpfNavigable.Front.ViewModels.Base;
using WpfNavigable.Front.Views;

namespace WpfNavigable.Front.ViewModels
{
    public class MainViewModel:ViewModelBase, IPageHost
    {
        public Dispatcher Dispatcher { get; }

        private Page currentPage;

        public Page CurrentPage
        {
            get => currentPage; 
            private set 
            {
                if (currentPage != value)
                {
                    currentPage = value;
                    OnPropertyChanged();
                }
            }
        }

        public IEnumerable<INavigable> ViewCollection { get; }

        public MainViewModel(IEnumerable<INavigable> viewCollection)
        {
            Dispatcher = Dispatcher.CurrentDispatcher;
            var pageCollection = viewCollection.Select(x => x as Page);
            ViewCollection = viewCollection;
            SetPage(nameof(WelcomeViewModel));
        }

        public void SetPage(string viewModelName)
        {
            var view  = ViewCollection.FirstOrDefault(x => x.ViewModelName == viewModelName);
            var page = view as Page;
            if (page != null)
            {
                Dispatcher.Invoke(() =>
                        CurrentPage = page,
                        DispatcherPriority.Background);
            }
        }
    }
}
