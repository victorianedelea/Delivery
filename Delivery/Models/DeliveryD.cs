using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Models;

namespace Delivery.Models
{
    public class DeliveryD
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string LocationName { get; set; }
        public string Adress { get; set; }
        public string DeliveryDetails
        {
            get
            {
                return LocationName + " " + Adress;} }
        [OneToMany]
 public List<DeliveryList> DeliveryLists { get; set; }
    }
}
