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

        public ObservableCollection<Page> PageCollection { get; }

        public MainViewModel(IEnumerable<INavigable> viewCollection)
        {
            Dispatcher = Dispatcher.CurrentDispatcher;
            var pageCollection = viewCollection.Select(x => x as Page);
            PageCollection = new ObservableCollection<Page>(pageCollection);
            SetPage(nameof(WelcomeView));
        }

        public void SetPage(string pageName)
        {
            var page  = PageCollection.FirstOrDefault(x => x.GetType().Name == pageName);

            Dispatcher.Invoke(() =>
                    CurrentPage = page,
                    DispatcherPriority.Background);
        }
    }
}
