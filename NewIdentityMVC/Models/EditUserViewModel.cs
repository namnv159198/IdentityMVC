using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewIdentityMVC.Models
{
    public class EditUserViewModel
    {
        public String ID { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public String Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "UserName")]
        [EmailAddress]
        public String UserName { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}