using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NewIdentityMVC.Models
{
    public class Role:IdentityRole
    {
        public Role()
        {

        }
        public Role( RoleViewModel roleViewModel)
        {
            this.Name = roleViewModel.Name;
        }
    }
}