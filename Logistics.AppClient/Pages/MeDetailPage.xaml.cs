using Logistics.AppClient.ViewModels;

namespace Logistics.AppClient.Pages;

public partial class MeDetailPage : ContentPage
{
	private readonly MeDetailViewModel meDetailViewModel;

	public MeDetailPage(MeDetailViewModel meDetailViewModel)
	{
		InitializeComponent();

		BindingContext = this.meDetailViewModel = meDetailViewModel;
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}