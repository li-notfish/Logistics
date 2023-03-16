using Logistics.AppClient.ViewModels;

namespace Logistics.AppClient.Pages;

public partial class NewOrderPage : ContentPage
{
	public NewOrderPage(NewOrderViewModel newOrderViewModel)
	{
		InitializeComponent();
		
		BindingContext = newOrderViewModel;
	}
}