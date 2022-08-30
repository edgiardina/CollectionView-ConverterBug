using CollectionView_BugRepro.Models;
using CollectionView_ConverterBug;

namespace CollectionView_BugRepro.ViewModels
{
    public class CellReuseBugViewModel : BaseViewModel
    {
        public bool IsLoaded { get; set; } = false;
        public Command ReloadCommand { get; }


        public string MeasurementUnitType
        {
            get
            {
                return App.LocalPreferences.UserDistanceUnit == LocalUserPreferences.DistanceUnit.Yards ? "Imperial" : "Metric";
            }
        }

        public CellReuseBugViewModel()
        {
            Title = "CollectionView Cell Reuse Bug";
            ReloadCommand = new Command(Reload);
            IsLoaded = true;
        }

        public void ToggleSelectedUnitOfMeasurement()
        {
            if (!IsBusy)
            {
                App.LocalPreferences.UserDistanceUnit = App.LocalPreferences.UserDistanceUnit == LocalUserPreferences.DistanceUnit.Yards ? LocalUserPreferences.DistanceUnit.Meters : LocalUserPreferences.DistanceUnit.Yards;
                OnPropertyChanged("MeasurementUnitType");
            }
        }

        public void OnAppearing()
        {
            Reload();
        }

        public void Reload()
        {
            IsBusy = true;
            OnPropertyChanged("MeasurementUnitType");
            IsBusy = false;
        }
    }
}