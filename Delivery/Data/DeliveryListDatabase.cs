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
            _database.CreateTableAsync<Colet>().Wait();
            _database.CreateTableAsync<ListColet>().Wait();

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

        public Task<int> SaveColetAsync(Colet colet)
        {
            if (colet.ID != 0)
            {
                return _database.UpdateAsync(colet);
            }
            else
            {
                return _database.InsertAsync(colet);
            }
        }
        public Task<int> DeleteColetAsync(Colet colet)
        {
            return _database.DeleteAsync(colet);
        }
        public Task<List<Colet>> GetColeteAsync()
        {
            return _database.Table<Colet>().ToListAsync();
        }

        public Task<int> SaveListColetAsync(ListColet listc)
        {
            if (listc.ID != 0)
            {
                return _database.UpdateAsync(listc);
            }
            else
            {
                return _database.InsertAsync(listc);
            }
        }
        public Task<List<Colet>> GetListColeteAsync(int deliverylistid)
        {
            return _database.QueryAsync<Colet>(
            "select C.ID, C.Description from Colet C"
            + " inner join ListColet LC"
            + " on C.ID = LC.ColetID where LC.DeliveryListID = ?",
            deliverylistid);
        }


    }
}


    

            
