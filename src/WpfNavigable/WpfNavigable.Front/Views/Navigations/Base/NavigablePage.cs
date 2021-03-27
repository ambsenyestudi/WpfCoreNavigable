using System.Windows.Controls;

namespace WpfNavigable.Front.Views.Navigations.Base

{
    public class NavigablePage
    {
        public string ViewModelName { get; }
        public Page Page { get; }

        public NavigablePage(Page page, object viewModel)
        {
            Page = page;
            Page.DataContext = viewModel;
            ViewModelName = viewModel.GetType().Name;
        }

        
    }
}
