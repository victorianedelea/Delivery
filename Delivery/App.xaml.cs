using System;
using Delivery.Data;
using System.IO;

namespace Delivery;

public partial class App : Application
{
    static DeliveryListDatabase database;
    public static DeliveryListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               DeliveryListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "DeliveryList.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
