using Delivery.Models;

namespace Delivery;

public partial class DeliveryPage : ContentPage
{
	public DeliveryPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var delivery = (DeliveryD)BindingContext;
        await App.Database.SaveDeliveryAsync(delivery);
        await Navigation.PopAsync();
    }

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var delivery = (DeliveryD)BindingContext;
        var address = delivery.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "locatie" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);
    }


}