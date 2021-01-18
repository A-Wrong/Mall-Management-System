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
    public class ShopOwner
    {

        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]//
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        [RegularExpression("[789]{1}[0-9]{9}", ErrorMessage = "Enter Valid Contact Number")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        [Key]
        public string Userid { get; set; }

        [Required(ErrorMessage = "Please update the highlighted mandatory field(s).")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        public BussinessProfile BussinessProfile{get;set;}
    }
}