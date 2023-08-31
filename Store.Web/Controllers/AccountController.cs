using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Store.Data;
using Store.Data.Repositories;
using Store.Model;
using Store.Model.Models;
using Store.Service;
using Store.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Roles = Store.Model.Models.Users;

namespace Store.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService UsersService;
        private readonly IRolesService RolesService;
        private readonly StoreSeedData _seedData;
        private readonly IEmployeesService EmployeesService;



        public AccountController(IUsersService UsersService, IEmployeesService EmployeesService, IRolesService RolesService)
        {
            this.UsersService = UsersService;
            this.RolesService = RolesService;
            this.EmployeesService = EmployeesService;
            _seedData = new StoreSeedData();
        }



        [HttpGet]
        public ActionResult Login()
        {
            //List<Users> users = new List<Users>();
            //users = UsersService.GetRoles().ToList();
            //RegisterEmployeeViewModel model = new RegisterEmployeeViewModel();
            //model.Roles = roles;
            //return View(model);
            return View();
        }



        [HttpPost]
        public ActionResult Login(UserFormViewModel model)
        {

            if (ModelState.IsValid)
            {
              
                var allUsers = StoreSeedData.GetUsers();
                var user = allUsers.FirstOrDefault(u => u.UserName == model.UserName);


                //var userid=user.ID
                //var Allroles=StoreSeedData.GetRoles();
                //var role=Allroles.Where(x =>x.ID==user.ID);
                //var Allmenu=StoreSeedData.GetMenus();
                //var menu=Allmenu.Where(x =>x.ID==user.ID);

                if (user != null && model.Password == user.PassWord)
                {
                    Session["IsLoggedIn"] = true; 
                    //ViewBag.UserMenus=menu;
                    Session["UserID"] = user.ID;
                    return RedirectToAction("Index", "Home");
                    
                }

            }


            return View();

        }
        [HttpPost]
        public ActionResult LogOut(UserFormViewModel model)
        {
            //FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            // Redirect to a page or action after logout
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
  
        //[HttpGet]
        //public ActionResult RegisterUsers()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult RegisterUsers(RegisterUserViewModel model)
        //{
        //    var allUsers = UsersService.GetUsers();
        //    var user = allUsers.FirstOrDefault(u => u.UserName == model.UserName);
        //    //var urr = allUsers.Where(u => u.UserName == model.UserName);

        //    if (user != null)
        //    {
        //        ModelState.AddModelError("UserName", "ასეთი იუზერი უკვე არსებოობს ბაზაში");

        //    }
        //    if (ModelState.IsValid)
        //    {
        //        var newUser = new Model.Models.Users()
        //        {
        //          UserName = model.UserName,
        //          PassWord = model.Password,
        //          RegistrationDate = DateTime.Now,

        //        };
        //        UsersService.CreateUser(newUser);
        //        UsersService.SaveUser();
        //        return RedirectToAction(nameof(HomeController.Index), "Home");

        //    }
        //   return View();
        
                  
            
            
        //    //return RedirectToAction(nameof(HomeController.Index), "Home");
        //}

    }
}