using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewIdentityMVC.Models
{
    public class AccountRegisterModel
    {
        [Required]
        public String UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public String Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public String Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = " Password mismatch")]
        public String PasswordConfirm { get; set; }

    }
}