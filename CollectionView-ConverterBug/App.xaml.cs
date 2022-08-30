using CollectionView_BugRepro.Models;
using CollectionView_BugRepro.Services;

namespace CollectionView_ConverterBug;

public partial class App : Application
{
    public static LocalUserPreferences LocalPreferences { get; set; } = new LocalUserPreferences();

    public App()
	{
		InitializeComponent();
        DependencyService.Register<MockDataStore>();
        MainPage = new AppShell();
	}
}
