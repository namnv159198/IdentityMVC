using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewIdentityMVC.Models
{
    public class LoginViewModel
    {
        [Required]
        public String UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public String Password { get; set; }
    }
}