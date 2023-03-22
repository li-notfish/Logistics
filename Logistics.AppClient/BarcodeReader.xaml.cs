using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ZXing.Net.Maui;

namespace Logistics.AppClient;

public partial class BarcodeReaderView : ContentPage
{
	public delegate void BarcodeDetected(string barcodeResult);
	public event BarcodeDetected OnBarcodeDetected;


    public BarcodeReaderView()
	{
		InitializeComponent();
		BarcodeReader.Options = new BarcodeReaderOptions
		{
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true
        };
	}

    private void BarcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(async () =>
        {
            if (OnBarcodeDetected != null)
            {
                OnBarcodeDetected(e.Results[0].Value);
                var toast = Toast.Make(e.Results[0].Value, ToastDuration.Short, 14);
                await toast.Show();
                CloseReader();
            }
        });
    }

    private void CloseReader()
    {
        Shell.Current.Navigation.PopModalAsync(true);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        CloseReader();
    }
}