using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Delivery.Models
{
    public class ListColet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(DeliveryList))]
        public int DeliveryListID { get; set; }
        public int ColetID { get; set; }
    }
}
