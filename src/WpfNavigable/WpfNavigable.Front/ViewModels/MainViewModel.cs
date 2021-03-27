using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using TicTacToe.Front;
using WpfNavigable.Front.ViewModels.Base;
using WpfNavigable.Front.Views;
using WpfNavigable.Front.Views.Navigations.Base;

namespace WpfNavigable.Front.ViewModels
{
    public class MainViewModel : ViewModelBase, IPageHost
    {
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

        public List<NavigablePage> ViewList { get; }

        public MainViewModel(IEnumerable<NavigablePage> viewCollection)
        {
            ViewList = new List<NavigablePage>(viewCollection);
            SetPage(nameof(WelcomeViewModel));
        }

        public void SetPage(string viewModelName)
        {
            var navigablePage = ViewList.FirstOrDefault(np => np.ViewModelName == viewModelName);
            if(navigablePage is not null)
            {
                if(viewModelName is nameof(WelcomeViewModel))
                {
                    CurrentPage = (WelcomeView)navigablePage.Page;
                }
                
            }
        }
    }
}
