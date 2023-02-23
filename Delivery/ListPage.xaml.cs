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
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ColetPage((DeliveryList)
       this.BindingContext)
        {
            BindingContext = new Colet()
        });

    }

   
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var deliveyl = (DeliveryList)BindingContext;

        listView.ItemsSource = await App.Database.GetListColeteAsync(deliveyl.ID);
    }

}