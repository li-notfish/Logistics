using Logistics.AppClient.ViewModels;

namespace Logistics.AppClient.Pages;

public partial class ExpressPage : ContentPage
{
	public ExpressPage(ExpressViewModel expressViewModel)
	{
		InitializeComponent();

		BindingContext = expressViewModel;
	}
}