using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopping_Mall_Management.Models
{
    [Table("Store")]
    public class Store
    {
        public int Storenumber { get; set; }
        public int Storesize { get; set; }
        public string Storelocation{get;set; } 
        public int StoreArea { get; set; }
        public string Occupancy_Status { get; set; }
        public string Type { get; set; }
        /*Lease amount per year / rent
If Occupied should have the below details also displayed
Shop Name, Business Category, Agreement Tenure etc*/
    }
}