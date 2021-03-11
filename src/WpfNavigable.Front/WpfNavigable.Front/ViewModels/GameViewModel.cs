using MediatR;
using WpfNavigable.Front.ViewModels.Base;

namespace WpfNavigable.Front.ViewModels
{
    public class GameViewModel:ViewModelBase
    {
        private readonly IMediator mediator;
        
        private string tl;
        public string TL 
        {
            get => tl;
            set
            {
                tl = value;
                OnPropertyChanged();
            }
        }
        public GameViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
