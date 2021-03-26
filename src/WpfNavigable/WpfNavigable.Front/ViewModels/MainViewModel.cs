using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using WpfNavigable.Front.ViewModels.Base;
using WpfNavigable.Front.Views;

namespace WpfNavigable.Front.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public string CurrentView
        {
            set 
            {
                CurrentPage = PageCollection.FirstOrDefault(x => x.GetType().Name == value);
            }
        }


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
            var pageCollection = viewCollection.Select(x => x as Page);
            PageCollection = new ObservableCollection<Page>(pageCollection);
            CurrentView = nameof(WelcomeView);
        }

        
    }
}
