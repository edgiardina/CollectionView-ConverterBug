using CollectionView_BugRepro.ViewModels;
using System;

namespace CollectionView_BugRepro.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = _viewModel.OnAppearingAsync();
        }
    }
}