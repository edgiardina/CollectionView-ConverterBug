using CollectionView_BugRepro.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionView_BugRepro.ViewModels
{
    public class DistanceItemsViewModel : BaseViewModel
    {
        public bool IsLoaded { get; set; } = false;

        public Command LoadItemsCommand { get; }

        public ObservableCollection<Item> Items { get; }

        public DistanceItemsViewModel()
        {
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            IsLoaded = true;
        }


        public async Task ExecuteLoadItemsCommand(bool sortByDistance = false)
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetMoreItemsAsync(true);
                if (sortByDistance)
                    items = items.OrderBy(x => x.Distance);

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

        public async Task ToggleSelectedUnitOfMeasurement(bool sortByDistance = false)
        {
            if (!IsBusy)
            {
                await ExecuteLoadItemsCommand(sortByDistance);
            }
        }


    }
}
