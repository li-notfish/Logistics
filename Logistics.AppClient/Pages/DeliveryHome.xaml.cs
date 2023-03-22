using Logistics.AppClient.ViewModels;

namespace Logistics.AppClient.Pages;

public partial class DeliveryHome : ContentPage
{
	private readonly DeliveryHomeViewModel viewModel;

	public DeliveryHome(DeliveryHomeViewModel deliveryHomeViewModel)
	{
		InitializeComponent();
		BindingContext = viewModel = deliveryHomeViewModel;
	}
}