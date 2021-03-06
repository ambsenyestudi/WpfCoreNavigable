using MediatR;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TicTacToe.Application.DTO;
using TicTacToe.Application.Games;
using TicTacToe.Application.Secrets;
using TicTacToe.Front;
using TicTacToe.Front.Models;
using TicTacToe.Front.Notifications;
using TicTacToe.Front.Queries;
using WpfNavigable.Front.ViewModels.Base;

namespace WpfNavigable.Front.ViewModels
{
    public class GameViewModel : ViewModelBase, IGameHost
    {
        

        public Dispatcher Dispatcher { get; }

        private readonly IMediator mediator;
        
        public Guid GameId { get; private set; }

        public ICommand PlayCommand { get; }

        private TicTacToeBoardLayout boardLayout = TicTacToeBoardLayout.Empty;

        public TicTacToeBoardLayout BoardLayout
        {
            get => boardLayout;
            set
            {
                boardLayout = value;
                OnPropertyChanged();
            }
        }

        public GameViewModel(IMediator mediator)
        {
            Dispatcher = Dispatcher.CurrentDispatcher;
            this.mediator = mediator;
            PlayCommand = new RelayCommand(PlaceChip);
        }

        private void PlaceChip(object obj)
        {
            //todo fire mediator message
            var position = obj as string;
            var (row, column) = ToRowColumn(position);
            if (CanPlayPosition(row, column))
            {
                Play(row, column);
            }
        }

        private async void Play(int row, int column)
        {
            await mediator.Publish(new ChipPlayed(GameId, row, column));
            var gameStatus = await mediator.Send(new GameStatusQuery(GameId));
            var gameSnapshot = await mediator.Send(new GameSnapshotQuery(GameId));
            var isUpdateBoard = TicTacToeBoardLayout.TryParse(gameSnapshot.BoardSnapshot, out TicTacToeBoardLayout parsedBoardLayout);
            
            Dispatcher.Invoke(() =>
            {
                if(isUpdateBoard)
                {
                    BoardLayout = parsedBoardLayout;
                }
                if(isEndOfGame(gameStatus))
                {
                    MessageBoxResult result = MessageBox.Show(gameStatus.DisplayName,
                     "Game ended",
                     MessageBoxButton.OK,
                     MessageBoxImage.Question);
                    Reset();
                    mediator.Publish(new Navigated(nameof(WelcomeViewModel)));
                }
            },DispatcherPriority.Background);
        }

        private bool isEndOfGame(GameStatusDTO gameStatus)
        {
            var status = gameStatus.Status;

            return status == GameStatus.Draw ||
                status == GameStatus.XWon ||
                status == GameStatus.OWon;
        }

        private (int, int) ToRowColumn(string boardPosition) => 
            boardPosition.ToRowAndColumn();

        private bool CanPlayPosition(int row, int column) =>
            IsValidPostion(row, column)
            ? IsPostionEmpty(row, column)
            : false;

        private bool IsPostionEmpty(int row, int column)
        {
            var square = BoardLayout.GetChip(row, column);
            return string.IsNullOrWhiteSpace(square);
        }

        private bool IsValidPostion(int row, int column) =>
            row >= 0 && column >= 0;

        public void Reset()
        {
            SetGameId(Guid.Empty);
            BoardLayout = TicTacToeBoardLayout.Empty;
        }

        public void SetGameId(Guid id) =>
            GameId = id;
    }
}
