using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Webshop.UI_MVC.Models;

namespace Webshop.UI_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        private ApplicationDbContext context;



        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET All Roles
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {


                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        private bool IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = userManager.GetRoles(user.GetUserId());
                for (int i = 0; i < s.Count; i++)
                {
                    if (s[i].ToString() == "Admin")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Create a Role
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Role = new IdentityRole();
            return View(Role);
        }

        // Create a Role
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (User.Identity.IsAuthenticated)
            {
                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            if (!roleManager.RoleExists(Role.Name))
            {
                context.Roles.Add(Role);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //GET: Roles/Edit/(id)
        public ActionResult Edit(string id)
        {
            var role = context.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //POST: Roles/Edit/(id)
        [HttpPost]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(role).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(role);
            }
            catch
            {
                return View(role);
            }
        }

        // GET: Roles/Delete/(id)
        public ActionResult Delete(string id)
        {
            var role = context.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //POST: Roles/Delete/(id)
        [HttpPost]
        public ActionResult Delete(IdentityRole rol)
        {
            IdentityRole role = context.Roles.Find(rol.Id);
            context.Roles.Remove(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}