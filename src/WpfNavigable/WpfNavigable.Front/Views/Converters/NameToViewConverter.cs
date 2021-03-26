using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfNavigable.Front.Views.Converters
{
    public class NameToViewConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
            object parameter, CultureInfo culture)
        {
            return FindCurrentView(values);
        }

        public object[] ConvertBack(
        object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private Page FindCurrentView(object[] values)
        {
            var viewName = FindViewName(values);
            var pageList = FindViewCollection(values);
            return pageList.FirstOrDefault(pa => pa.GetType().Name == viewName);
        }

        private string FindViewName(object[] values) =>
            FindObject<string>(values);

        private ObservableCollection<Page> FindViewCollection(object[] values) =>
            FindObject<ObservableCollection<Page>>(values);

        private T FindObject<T>(object[] values) => 
            (T)values.FirstOrDefault(x=>x.GetType() == typeof(T));
        
    }
}
