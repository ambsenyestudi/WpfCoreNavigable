using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfNavigable.Front.Views.Converters
{
    public class BoardLayoutConverter : IValueConverter
    {
        public const int BOARD_SIZE = 3;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boardLayout = value as string;
            var serializedPostion = parameter as string;
            if (!TryParseRowColumn(serializedPostion, out int row, out int column))
            {
                return string.Empty;
            }
            var result = ParseBoardLayout(boardLayout, row, column);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private object ParseBoardLayout(string boardLayout, int row, int column)
        {
            var boardPositions = boardLayout.Split(',');
            var index = PostionToIndex(row, column);
            var result = boardPositions[index];
            return result;
        }

        private int PostionToIndex(int row, int column) =>
            row * BOARD_SIZE + column;

        private bool TryParseRowColumn(string serializedPostion, out int row, out int column)
        {

            if (string.IsNullOrWhiteSpace(serializedPostion))
            {
                row = -1;
                column = -1;
                return false;
            }

            if (!TryParseRow(serializedPostion, out int parsedRow))
            {
                row = -1;
                column = -1;
                return false;
            }

            if (!TryParseColumn(serializedPostion, out int parsedColumn))
            {
                row = parsedRow;
                column = -1;
                return false;
            }
            row = parsedRow;
            column = parsedColumn;
            return true;
        }

        private bool TryParseRow(string serializedPostion, out int row) =>
            TryParsePostions(serializedPostion, 0, out row);
        private bool TryParseColumn(string serializedPostion, out int column) =>
            TryParsePostions(serializedPostion, 1, out column);

        private bool TryParsePostions(string serializedPostion, int  position, out int parsedPosition)
        {
            var rawPosition = ExtractPostionsComponent(serializedPostion, position);
            if (!int.TryParse(rawPosition, out int parsedRawPosition))
            {
                parsedPosition = -1;
                return false;
            }
            parsedPosition = parsedRawPosition;
            return true;
        }

        private string ExtractPostionsComponent(string serializedPostions, int position) =>
            serializedPostions[position].ToString();
    }
}
