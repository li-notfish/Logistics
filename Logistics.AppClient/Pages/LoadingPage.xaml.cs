namespace Logistics.AppClient.Pages;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		if(await IsLogin())
		{
			await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
		}
		else
		{
			await Shell.Current.GoToAsync(nameof(LoginPage));
		}
	}

	async Task<bool> IsLogin()
	{
		await Task.Delay(1000);
		var login = await SecureStorage.GetAsync("IsLogin");
		return !(login == null);
	}
}