using System;
using System.Globalization;
using System.Linq;

namespace CollectionView_BugRepro.Converters
{
    public class IndexOfCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return -1;

            if (parameter is CollectionView)
            {
                return ((CollectionView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value) + 1;
            }
            else
            {
                return ((ListView)parameter).ItemsSource.Cast<object>().ToList().IndexOf(value) + 1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

    }
}
