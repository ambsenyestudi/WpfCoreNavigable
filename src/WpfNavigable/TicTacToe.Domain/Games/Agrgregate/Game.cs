using System;
using System.Linq;

namespace TicTacToe.Domain.Games.Agrgregate
{
    public class Game
    {

        public GameId Id { get; }

        private readonly BoardState boardState;
        private Board board;
        private GameStatus status;

        public Game(GameId id, string gameLayout="")
        {
            Id = id;
            boardState = BoardState.Empty;
            status = GameStatus.Playing;
            board = new Board();
            SetGameLayout(gameLayout);
            
        }

        public override string ToString() =>
            board.ToString();

        public BoardState GetBoardState() =>
            boardState;
        public GameStatus GetStatus() => 
            status;

        public string Play(BoardRowColumn boardRowColumn)
        {
            var result = board.Play(boardRowColumn.ToListIndex());
            UpdateStatus();
            return result;
        }

        private void UpdateStatus()
        {
            if(board.IsFull())
            {
                status = GameStatus.Draw;
            }
            var winner = board.GetWinner();

            if (winner == new MatchResult(ChipTypes.X))
            {
                status = GameStatus.XWon;
            }
            if (winner == new MatchResult(ChipTypes.O))
            {
                status = GameStatus.OWon;
            }
        }


        private void SetGameLayout(string gameLayout)
        {
            if(!string.IsNullOrWhiteSpace(gameLayout))
            {
                var plays = gameLayout.Split(",");
                PlayLayout(plays);
            }
        }

        private void PlayLayout(string[] plays)
        {
            var moveList = plays.Select((play, index) => new { ChipType = ToChipType(play), index = index });
            var xMoveList = moveList.Where(x => x.ChipType == ChipTypes.X).ToList();
            var oPositionList = moveList.Where(x => x.ChipType == ChipTypes.O).ToList();
            for (int i = 0; i < xMoveList.Count; i++)
            {
                var currentX = ListIndex.Create(xMoveList[i].index);
                board.Play(currentX);
                if (i < oPositionList.Count)
                {
                    var currentO = ListIndex.Create(oPositionList[i].index);
                    board.Play(currentO);
                }
            }
            UpdateStatus();
        }

        private ChipTypes ToChipType(string play)
        {
            if(!Enum.TryParse<ChipTypes>(play, out ChipTypes chip))
            {
                return ChipTypes.None;
            }
            return chip;
        }
    }
}
