using CollectionView_BugRepro.ViewModels;
using System.Threading.Tasks;

namespace CollectionView_BugRepro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DistanceItemsView : ContentView
    {

        DistanceItemsViewModel viewModel;
        public DistanceItemsView()
        {
            InitializeComponent();

            BindingContext = viewModel = new DistanceItemsViewModel();
            _ = viewModel.ExecuteLoadItemsCommand(checkbox_distance.IsChecked);
        }

        public async Task ToggleUnitOfMeasurement_Clicked()
        {
            await viewModel.ToggleSelectedUnitOfMeasurement(checkbox_distance.IsChecked);
        }

        public async Task RefreshData()
        {
            await viewModel.ExecuteLoadItemsCommand(checkbox_distance.IsChecked);
        }

        public void OnAppearing()
        {
            _ = viewModel.ExecuteLoadItemsCommand(checkbox_distance.IsChecked);
        }

        private async void SortByDistance_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            await viewModel.ExecuteLoadItemsCommand(checkbox_distance.IsChecked);
        }

        private void CheckboxLayout_Tapped(object sender, System.EventArgs e)
        {
            checkbox_distance.IsChecked = !checkbox_distance.IsChecked;
        }
    }
}