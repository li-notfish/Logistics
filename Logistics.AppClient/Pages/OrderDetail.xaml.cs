using Logistics.AppClient.ViewModels;

namespace Logistics.AppClient.Pages;

public partial class OrderDetail : ContentPage
{
	private readonly OrderDetailViewModel orderDetailViewModel;

	public OrderDetail(OrderDetailViewModel orderDetailViewModel)
	{
		InitializeComponent();
		BindingContext = this.orderDetailViewModel = orderDetailViewModel;

    }
}