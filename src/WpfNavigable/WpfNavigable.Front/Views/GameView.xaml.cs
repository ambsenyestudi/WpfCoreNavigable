using System.Windows.Controls;
using WpfNavigable.Front.ViewModels;

namespace WpfNavigable.Front.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Page, INavigable
    {
        public string ViewModelName { get; }
        public GameView(GameViewModel viewModel)
        {
            ViewModelName = viewModel.GetType().Name;
            DataContext = viewModel;
            InitializeComponent();
        }

        
    }
}
