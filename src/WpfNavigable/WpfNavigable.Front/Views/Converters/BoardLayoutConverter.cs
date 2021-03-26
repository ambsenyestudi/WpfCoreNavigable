using System;
using System.Globalization;
using System.Windows.Data;
using TicTacToe.Front.Models;

namespace WpfNavigable.Front.Views.Converters
{
    public class BoardLayoutConverter : IValueConverter
    {
        
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boardLayout = value as TicTacToeBoardLayout;
            var serializedUnseparatedPostion = parameter as string;
            var (row,column) = serializedUnseparatedPostion.ToRowAndColumn();
           
            if (row < 0 || column < 0 )
            {
                return string.Empty;
            }
            
            var result = boardLayout.GetChip(row, column);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        

        

        
    }
}
