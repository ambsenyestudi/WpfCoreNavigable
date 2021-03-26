using System.Windows.Controls;
using WpfNavigable.Front.ViewModels;

namespace WpfNavigable.Front.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Page, INavigable
    {
        public string ViewName => nameof(GameView);
        public GameView(GameViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        
    }
}
