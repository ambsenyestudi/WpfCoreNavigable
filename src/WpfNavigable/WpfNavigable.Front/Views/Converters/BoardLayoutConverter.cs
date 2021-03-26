using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using TicTacToe.Domain.Games;

namespace WpfNavigable.Front.Views.Converters
{
    public class BoardLayoutConverter : IValueConverter
    {
        public const int BOARD_SIZE = 3;
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boardLayout = value as string;
            var serializedUnseparatedPostion = parameter as string;
            var (row,column) = serializedUnseparatedPostion.ToRowAndColumn();
           
            if (row<0||column<0)
            {
                return string.Empty;
            }
            var boardRowColumn = BoardRowColumn.Create(row, column);
            var result = ParseBoardLayout(boardLayout, boardRowColumn);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private object ParseBoardLayout(string boardLayout, BoardRowColumn boardRowColumn)
        {
            var boardPositions = boardLayout.Split(',');
            var index = PostionToIndex(boardRowColumn.Row, boardRowColumn.Column);
            var result = boardPositions[index];
            return result;
        }

        private int PostionToIndex(int row, int column) =>
            row * BOARD_SIZE + column;

        
    }
}
