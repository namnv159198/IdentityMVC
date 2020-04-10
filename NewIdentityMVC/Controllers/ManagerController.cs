using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NewIdentityMVC.Data;
using NewIdentityMVC.Models;

namespace NewIdentityMVC.Controllers
{
    public class ManagerController : Controller
    {
        private NewIdentityMVCContext db = new NewIdentityMVCContext();
        private RoleManager<Role> roleManager;
        public ManagerController()
        {
            db = new NewIdentityMVCContext();
            roleManager = new RoleManager<Role>(new RoleStore<Role>(db));
            // RoleManager : Quản lý Role
            // RoleStore : Lưu trữ Role (Account), muốn lưu thì phải thông qua DBContext (db)

        }

        public ActionResult ListRole()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }
        public ActionResult ListUser()
        {
            var ListUser = db.Users.ToList();
            return View(ListUser);
        }


        public ActionResult CreateRole()
        {
            return View();
        }
        // GET: Manager
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRole(RoleViewModel roleViewModel)
        {

            if (ModelState.IsValid)
            {
                var role = new Role(roleViewModel);
                var roleresult = await roleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("listRole");
            }
            return View();
        }
    }
}