using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Logistics.AppClient.ViewModels;
using Logistics.Shared.Model;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace Logistics.AppClient;

public partial class BarcodeReaderView : ContentPage
{
	public delegate void BarcodeDetected(string barcodeResult);
	public event BarcodeDetected OnBarcodeDetected;

    private readonly BarcodeReaderViewModel barcodeReaderViewModel;

    public BarcodeReaderView()
	{
		InitializeComponent();
        barcodeView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true
        };
        barcodeReaderViewModel = new BarcodeReaderViewModel();
    }

    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        foreach (var barcode in e.Results)
            Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");

        var first = e.Results?.FirstOrDefault();
        if (first is not null)
        {
            Dispatcher.Dispatch(async () =>
            {
                barcodeGenerator.ClearValue(BarcodeGeneratorView.ValueProperty);
                barcodeGenerator.Format = first.Format;
                barcodeGenerator.Value = first.Value;
                var navigationParamters = new Dictionary<string, object>();
                navigationParamters.Add("orderId", first.Value);
                await Shell.Current.GoToAsync($"{nameof(Pages.OrderDetail)}", navigationParamters);
            });
        }
    }

    void TorchButton_Clicked(object sender, EventArgs e)
    {
        barcodeView.IsTorchOn = !barcodeView.IsTorchOn;
    }

    void Close_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PopAsync();
    }
}