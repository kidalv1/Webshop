using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Webshop.UI_MVC.Models;

namespace Webshop.UI_MVC.Controllers
{
    public class UserController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext context;

        public UserController()
        {
            context = new ApplicationDbContext();
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { _signInManager = value; }
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        // GET: Users
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var allUsers = context.Users.Where(user => user.UserName != "admin").ToList();
            return View(allUsers);
        }

        //
        // GET: /User/Register
        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin"))
                .ToList(), "Name", "Name");
            return View();
        }

        //
        // POST: /User/Register
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, Webshop.BL.EmailService service)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {UserName = model.Email, Email = model.Email};
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //  Comment the following line to prevent log in until the user is confirmed.
                    //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new {userId = user.Id, code = code},
                        protocol: Request.Url.Scheme);
                    service.SendMail(user.Email, user.Id, "Confirm your account",
                        "Please confirm your account by clicking " + callbackUrl);
                    //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    //Assign Role to user Here       
                    await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);

                    ViewBag.Message = "Check je email en bevestig je account, je moet dit doen "
                                      + "vooraleer je kan inloggen.";

                    return View("Info");
                    //return RedirectToAction("Index", "Home");
                }

                ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin"))
                    .ToList(), "Name", "Name");
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: User/Details
        public ActionResult Details()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userid = User.Identity.GetUserId();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                ApplicationUser user = userManager.FindByIdAsync(userid).Result;

                return View(user);
            }
            else return RedirectToAction("Login", "Account");
        }

        // GET: User/Details
        public ActionResult DetailsOtherUser(string id)
        {
            var userid = id;
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ApplicationUser user = userManager.FindByIdAsync(userid).Result;

            return View(user);
        }

        //GET: Users/Edit/{id}
        public ActionResult Edit(string id)
        {
            ApplicationUser appUser = new ApplicationUser();
            appUser = UserManager.FindById(id);
            ApplicationUser user = new ApplicationUser();
            user.Address = appUser.Address;
            user.Email = appUser.Email;
            user.Firstname = appUser.Firstname;
            user.Surname = appUser.Surname;
            user.Address = appUser.Address;
            user.ZIPCode = appUser.ZIPCode;
            user.PhoneNumber = appUser.PhoneNumber;

            return View(user);
        }

        //POST: Users/Edit/{id}
        [HttpPost]
        public async Task<ActionResult> Edit(ApplicationUser model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindByEmail(model.Email);
            currentUser.Address = model.Address;
            currentUser.Email = model.Email;
            currentUser.Firstname = model.Firstname;
            currentUser.Surname = model.Surname;
            currentUser.Address = model.Address;
            currentUser.ZIPCode = model.ZIPCode;
            currentUser.PhoneNumber = model.PhoneNumber;
            await manager.UpdateAsync(currentUser);
            TempData["msg"] = "Profile Changes Saved !";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = context.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ApplicationUser user)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            context.Users.Attach(user);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["UserDeleted"] = "User Successfully Deleted";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UserDeleted"] = "Error Deleting User";
                return RedirectToAction("Index");
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}