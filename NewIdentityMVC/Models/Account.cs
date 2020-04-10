using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NewIdentityMVC.Models
{
    public class Account : IdentityUser
    {
        public Account()
        {

        }

        public Account(AccountRegisterModel accountRegisterModel)
        {
            this.UserName = accountRegisterModel.UserName;
            this.Email = accountRegisterModel.Email;
            this.PasswordHash = accountRegisterModel.Password;
            

        }
        public string RollNumber { get; set; }
        public String Address { get; set; }

    }
}