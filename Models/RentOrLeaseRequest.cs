using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopping_Mall_Management.Models
{
    public class RentOrLeaseRequest
    {
        [Key]
        [Display(Name ="Request ID")]
        public int RequestId { get; set; }
        [Display(Name = "Store Number")]
        [ForeignKey("Store")]
        public String StoreNumber { get; set; }
        [Display(Name = "Store Location")]
        public String StoreLocation { get; set; }
        [Display(Name = "Type")]
        public String Type { get; set; }
        [Display(Name = "Store Owner Name")]
        public String StoreOwnerName { get; set; }
        [Display(Name = "Contact Number")]
        public String ContactNumber { get; set; }
        [Display(Name = "Business Category")]
        public String BusinessCategory { get; set; }
        [Display(Name = "Tenure")]
        public int Tenure { get; set; }
        [Display(Name = "Status")]
        public String Status { get; set; }
        public Store Store { get; set; }
    }
}