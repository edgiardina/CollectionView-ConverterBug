using CollectionView_BugRepro.ViewModels;
using System;

namespace CollectionView_BugRepro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellReuseBugPage : ContentPage
    {
        CellReuseBugViewModel viewModel;

        public CellReuseBugPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CellReuseBugViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
            DistanceItemsView.OnAppearing();
        }

        private async void ToggleMeasurementUnits_Clicked(object sender, EventArgs e)
        {
            viewModel.ToggleSelectedUnitOfMeasurement();
            await DistanceItemsView.ToggleUnitOfMeasurement_Clicked();
        }

        //Workaround to tell child-view it needs to refresh when this page's RefreshView has finished running.
        private async void RefreshView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsRefreshing")
            {
                var refreshView = (RefreshView)sender;
                if (refreshView != null && refreshView.IsRefreshing == false)
                    await DistanceItemsView.RefreshData();
            }
        }
    }
}