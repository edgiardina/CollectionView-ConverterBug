using CollectionView_BugRepro.Models;
using CollectionView_ConverterBug;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CollectionView_BugRepro.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<Item> ItemTapped { get; }

        public Command ToggleMeasurementUnitCommand { get; }

        public string MeasurementUnitType
        {
            get
            {
                return App.LocalPreferences.UserDistanceUnit == LocalUserPreferences.DistanceUnit.Yards ? "Imperial" : "Metric";
            }
        }


        public ItemsViewModel()
        {
            Title = "CollectionView Refresh Bug";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ToggleMeasurementUnitCommand = new Command(async () => await ToggleSelectedUnitOfMeasurement());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ToggleSelectedUnitOfMeasurement()
        {
            if (!IsBusy)
            {
                App.LocalPreferences.UserDistanceUnit = App.LocalPreferences.UserDistanceUnit == LocalUserPreferences.DistanceUnit.Yards ? LocalUserPreferences.DistanceUnit.Meters : LocalUserPreferences.DistanceUnit.Yards;
                OnPropertyChanged("MeasurementUnitType");
                await ExecuteLoadItemsCommand();
            }
        }

        public async Task OnAppearingAsync()
        {
            IsBusy = true;
            OnPropertyChanged("MeasurementUnitType");
            await ExecuteLoadItemsCommand();
        }


    }
}