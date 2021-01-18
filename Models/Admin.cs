using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shopping_Mall_Management.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Required(ErrorMessage="User ID Not present")]
        public string userid { get; set; }
        [Required(ErrorMessage ="Password not matching")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}