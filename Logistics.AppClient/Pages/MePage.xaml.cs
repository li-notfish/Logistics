using Logistics.AppClient.ViewModels;

namespace Logistics.AppClient.Pages;

public partial class MePage : ContentPage
{
	public MePage(MeViewModel meViewModel)
	{
		InitializeComponent();

		BindingContext = meViewModel;
	}

}