using System.Windows.Controls;
using WpfNavigable.Front.ViewModels;

namespace WpfNavigable.Front.Views
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : Page, INavigable
    {
        public WelcomeView(WelcomeViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
