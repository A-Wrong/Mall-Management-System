using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

//first name,last name,dob,gender,contact number,email,category,userid,password
namespace Shopping_Mall_Management.Models
{
    [Table("User_Details")]
    public class Shop_Owner
    {
        
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public string first_name { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public string last_name { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date_of_birth { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public long contact_number { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public string category { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public string userid { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}