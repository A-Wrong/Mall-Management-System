using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopping_Mall_Management.Models
{
    public class BussinessProfile
    {
        [Key]
        [ForeignKey("ShopOwner")]

        public String BussinessProfileId { get; set; }
        public String ShopName { get; set; }
        public String BusinessCategory { get; set; }
        //– Service, Hotel, Super Market, Boutique, Entertainment zone, Coffee shop, Fast food, Ice cream parlour, Haircut & SPA, Sports shop, Electronics & Gadgets, Books, Clothing, Jewelery & Accessory, Perfume shop, Watch etc
        public int TotalEmployees { get; set; }
        public int Workinghours { get; set; }
        public String Holiday { get; set; }
        public String LicenseNumber { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
       
       // public String Userid { get; set; }
        public ShopOwner ShopOwner { get; set; }
        

    }
}