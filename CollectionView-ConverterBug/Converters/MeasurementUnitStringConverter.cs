using CollectionView_ConverterBug;
using System;
using System.Globalization;

namespace CollectionView_BugRepro.Converters
{
    internal class MeasurementUnitStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string)
            {
                if (String.Equals((string)value, "Yards", 
                    StringComparison.OrdinalIgnoreCase)) //Distance, Full Text
                {
                    switch (App.LocalPreferences.UserDistanceUnit)
                    {
                        case Models.LocalUserPreferences.DistanceUnit.Yards:
                            return "Yards";
                        case Models.LocalUserPreferences.DistanceUnit.Meters:
                            return "Meters";
                    }
                }
                else if (String.Equals((string)value, "yds", 
                        StringComparison.OrdinalIgnoreCase)) //Distance, Abbreviated
                {
                    switch (App.LocalPreferences.UserDistanceUnit)
                    {
                        case Models.LocalUserPreferences.DistanceUnit.Yards:
                            return "yds";
                        case Models.LocalUserPreferences.DistanceUnit.Meters:
                            return "m";
                    }
                }

                return value;
            }
            else
            {
                return value ?? String.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
