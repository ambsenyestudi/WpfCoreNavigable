using MediatR;
using System;
using System.IO;
using System.Windows.Input;
using WpfNavigable.Front.Notifications;
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

        public Guid GameId { get; set; }

        public ICommand PlayCommand { get; }

        private string boardLayout = ",,,,,,,,";

        public string BoardLayout
        {
            get => boardLayout;
            set
            {
                boardLayout = value;
                OnPropertyChanged();
            }
        }


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
        private string tc;

        public string TC
        {
            get => tc;
            set 
            { 
                tc = value;
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
            //todo fire mediator message
            var position = obj as string;
            if(CanPlayPosition(position))
            {
                Play(position);
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

        private async void Play(string boardPosition)
        {
            var (row, column) = ToRowColumn(boardPosition);
            await mediator.Publish(new ChipPlayed(GameId, row, column));
        }

        private (int, int) ToRowColumn(string boardPosition)
        {
            if(boardPosition.StartsWith("T"))
            {
                return (0, GetColumn(boardPosition[1]));
            }
            if (boardPosition.StartsWith("M"))
            {
                return (1, GetColumn(boardPosition[1]));
            }
            if (boardPosition.StartsWith("B"))
            {
                return (2, GetColumn(boardPosition[1]));
            }

            return (-1, -1);
        }

        private int GetColumn(char column)
        {
            if(column=='R')
            {
                return 2;
            }
            if(column=='C')
            {
                return 1;
            }
            return 0;
        }

        private bool CanPlayPosition(string position) =>
            IsValidPostion(position)
            ? IsPostionEmpty(position)
            : false;

        private bool IsPostionEmpty(string position)
        {
            var boardPostion = GetPostionsFromName(position);
            return string.IsNullOrEmpty(boardPostion);
        }

        private bool IsValidPostion(string position) =>
            !string.IsNullOrWhiteSpace(position) && 
                Enum.TryParse<BoardPositions>(position, out BoardPositions bPosition);

        private string GetPostionsFromName(string posName)
        {
            var pInfo = this.GetType().GetProperty(posName);
            return pInfo.GetValue(this) as string;
        }
    }
}
