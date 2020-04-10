using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using NewIdentityMVC.Data;
using NewIdentityMVC.Models;

namespace NewIdentityMVC.Controllers
{
    public class AccountController : Controller
    {
        private NewIdentityMVCContext db;

        private UserManager<Account> userManager;
        public AccountController()
        {
            db = new NewIdentityMVCContext();
            userManager = new UserManager<Account>(new UserStore<Account>(db));
            // UserManager : Quản lý User
            // UserStore : Lưu trữ User (Account), muốn lưu thì phải thông qua DBContext (db)
            
        }
        // GET: Account
        public ActionResult Index()
        {
            return View("Register");
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAccount(AccountRegisterModel accountRegisterModel)
        {
            if (ModelState.IsValid)
            {
                var account = new Account(accountRegisterModel);
                IdentityResult result = await userManager.CreateAsync(account, accountRegisterModel.Password);
                // Dùng async để tránh việc lỗi khi tạo User thì nó chưa tạo ID khi muốn role cho User
                // Lưu ý : Password trong bảng Identity User được định dạng đầy đủ 
                // 1 Ký tự đặc biệt
                // 2 Số
                // 3 Chữ in hoa
                // Nếu không đầy đủ thì nó sẽ không băm , result sẽ là Null 
                // Phải validate Password trong AccountRegister định dạng 
                if (result.Succeeded)
                {
                    // nên đăng nhập luôn.
                    TempData["message"] = "Register success!";
                    return Redirect("/Home");
                }
            }
            return View("Register", accountRegisterModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            var account = userManager.Find(loginViewModel.UserName, loginViewModel.Password);
            if (account != null)
            {
                var ident = userManager.CreateIdentity(account, DefaultAuthenticationTypes.ApplicationCookie);
                // Tạo cookie cho user khi login [Account]
                //use the instance that has been created. 
                HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                TempData["message"] = "Login success!";
                return Redirect("/Home");
            }
            return Redirect("/Account/Login");
        }
        public ActionResult Logout()
        {
            TempData["message"] = "Logout success!";
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Home");
        }
    }
}