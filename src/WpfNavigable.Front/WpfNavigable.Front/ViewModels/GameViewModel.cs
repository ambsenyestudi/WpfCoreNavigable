using MediatR;
using System;
using System.Windows.Input;
using WpfNavigable.Front.ViewModels.Base;

namespace WpfNavigable.Front.ViewModels
{
    public enum BoardPositions
    {
        None, TL, TC, TR,
        ML, MC, MR,
        BL, BC, BR,
    }
    public class GameViewModel:ViewModelBase
    {
        private readonly IMediator mediator;

        public ICommand PlayCommand { get; }

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
            PlayCommand = new RelayCommand(PlaceChip);
        }

        private void PlaceChip(object obj)
        {
            var position = obj as string;
            if(CanPlayPosition(position))
            {
                TL="X";
            }
        }

        private bool CanPlayPosition(string position) =>
            IsValidPostion(position)
            ? IsPostionEmpty(position)
            : false;

        private bool IsPostionEmpty(string position)
        {
            return string.IsNullOrEmpty(TL);
        }

        private bool IsValidPostion(string position) =>
            !string.IsNullOrWhiteSpace(position) && 
                Enum.TryParse<BoardPositions>(position, out BoardPositions bPosition);
    }
}
