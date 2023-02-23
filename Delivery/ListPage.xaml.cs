using Delivery.Models;

namespace Delivery;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (DeliveryList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveDeliveryListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (DeliveryList)BindingContext;
        await App.Database.DeleteDeliveryListAsync(slist);
        await Navigation.PopAsync();
    }

}