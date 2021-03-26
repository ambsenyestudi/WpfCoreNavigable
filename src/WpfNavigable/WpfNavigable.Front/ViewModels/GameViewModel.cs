using MediatR;
using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Threading;
using TicTacToe.Domain;
using WpfNavigable.Front.Notifications;
using WpfNavigable.Front.Queries;
using WpfNavigable.Front.ViewModels.Base;
using TicTacToe.Front.Models;

namespace WpfNavigable.Front.ViewModels
{
    public class GameViewModel:ViewModelBase
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
            //Move all of this to encryption service
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path += @"\TicTacToe";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var key = "123456789";
            var filename = $@"{path}\WriteFile.txt";
            var encryptedText = EncryptionHelper.Encrypt("Hello world", key);
            File.WriteAllText(filename, encryptedText);
            var readText = File.ReadAllText(filename);
            Console.WriteLine(readText);
            var regularText = EncryptionHelper.Decrypt(readText, key);
            Console.WriteLine(regularText);

        }

        public void Reset(GameId gameId)
        {
            GameId = gameId.Value;
            BoardLayout = TicTacToeBoardLayout.Empty;
        }

        private async void Play(int row, int column)
        {
            await mediator.Publish(new ChipPlayed(GameId, row, column));
            var boardLayout = await mediator.Send(new BoardLayoutQuery(GameId));
            Dispatcher.Invoke(() =>
            {
                if(TicTacToeBoardLayout.TryParse(boardLayout, out TicTacToeBoardLayout parsedBoardLayout))
                {
                    BoardLayout = parsedBoardLayout;
                }
            },DispatcherPriority.Background);
        }

        private (int, int) ToRowColumn(string boardPosition) => 
            boardPosition.ToRowAndColumn();

        private bool CanPlayPosition(int row, int column) =>
            IsValidPostion(row, column)
            ? IsPostionEmpty(row, column)
            : false;

        private bool IsPostionEmpty(int row, int column)
        {
            //todo
            return true;
        }

        private bool IsValidPostion(int row, int column) =>
            row >= 0 && column >= 0;

        
    }
}
