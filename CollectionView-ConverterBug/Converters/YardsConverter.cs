using CollectionView_ConverterBug;
using System;
using System.Globalization;

namespace CollectionView_BugRepro.Converters
{
    internal class YardsConverter : IValueConverter
    {
        private const double YardsToMeters = 0.9144;

        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double valueAsNumber;

            if (value != null && Double.TryParse(value.ToString(), out valueAsNumber))
            {
                switch (App.LocalPreferences.UserDistanceUnit)
                {
                    case Models.LocalUserPreferences.DistanceUnit.Yards:
                        return value;
                    case Models.LocalUserPreferences.DistanceUnit.Meters:
                        valueAsNumber = valueAsNumber * YardsToMeters;
                        break;
                }

                //Return either an int or a double with 2 decimal places depending on whether or not value was an int to begin with.
                return value is int ? Math.Round(valueAsNumber) : Math.Round(valueAsNumber, 2);
            }
            else
            {
                return value;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
