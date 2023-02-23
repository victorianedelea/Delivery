using Delivery.Models;

namespace Delivery;

public partial class ColetPage : ContentPage
{
   public DeliveryList dl;
	public ColetPage(DeliveryList dlist)
	{
		InitializeComponent();
        dl = dlist;
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Colet)BindingContext;
        await App.Database.SaveColetAsync(product);
        listView.ItemsSource = await App.Database.GetColeteAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Colet)BindingContext;
        await App.Database.DeleteColetAsync(product);
        listView.ItemsSource = await App.Database.GetColeteAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetColeteAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Colet c;
        if (listView.SelectedItem != null)
        {
            c = listView.SelectedItem as Colet;
            var lc = new ListColet()
            {
                DeliveryListID = dl.ID,
                ColetID = c.ID
            };
            await App.Database.SaveListColetAsync(lc);
            c.ListColete = new List<ListColet> { lc };
            await Navigation.PopAsync();
        }


    }

}