using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Delivery.Models;

namespace Delivery.Data
{
    public class DeliveryListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public DeliveryListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DeliveryList>().Wait();
        }
        public Task<List<DeliveryList>> GetDeliveryListsAsync()
        {
            return _database.Table<DeliveryList>().ToListAsync();
        }
        public Task<DeliveryList> GetDeliveryListAsync(int id)
        {
            return _database.Table<DeliveryList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveDeliveryListAsync(DeliveryList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteDeliveryListAsync(DeliveryList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
            
