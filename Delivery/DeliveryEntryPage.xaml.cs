using Delivery.Models;

namespace Delivery;

public partial class DeliveryEntryPage : ContentPage
{
	public DeliveryEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetDeliveriesAsync();
    }
    async void OnDeliveryAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DeliveryPage
        {
            BindingContext = new DeliveryD()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new DeliveryPage
            {
                BindingContext = e.SelectedItem as DeliveryD
            });
        }
    }


}