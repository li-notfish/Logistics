using Logistics.AppClient.ViewModels;

namespace Logistics.AppClient.Pages;

public partial class LoginPage : ContentPage
{
	private readonly LoginViewModel loginViewModel;
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		this.loginViewModel = loginViewModel;
		BindingContext = loginViewModel;
	}
}