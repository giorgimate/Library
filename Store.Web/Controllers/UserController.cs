using AutoMapper;
using DocumentFormat.OpenXml.EMMA;
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
using Users = Store.Model.Models.Users;
using Roles = Store.Model.Models.Roles;

namespace Store.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersService UsersService;
        private readonly IRolesService RolesService;
        private readonly StoreSeedData _seedData;
        private readonly IEmployeesService EmployeesService;



        public UserController(IUsersService UsersService, IEmployeesService EmployeesService, IRolesService RolesService)
        {
            this.UsersService = UsersService;
            this.RolesService = RolesService;
            this.EmployeesService = EmployeesService;
            _seedData = new StoreSeedData();

        }

        public ActionResult Index()
        {
            var users = UsersService.GetUsers().ToList();
            return View(users);
        }


        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(RegisterUserViewModel model)
        {
            int employeeId = 0;
            var allUsers = UsersService.GetUsers();
            var sameUserEmail = UsersService.GetUserByEmail(model.EmployeeEmail);
            var user = allUsers.FirstOrDefault(u => u.UserName == model.UserName);
            //var urr = allUsers.Where(u => u.UserName == model.UserName);
            var AllEmployeeEmails = EmployeesService.GetEmployees();
            var Employeee = AllEmployeeEmails.FirstOrDefault(u => u.Email == model.EmployeeEmail);
            

            if (user != null)
            {
                ModelState.AddModelError("UserName", "ასეთი იუზერი უკვე არსებოობს ბაზაში");

            }
            if(sameUserEmail != null)
            {
                ModelState.AddModelError("EmployeeEmail", "იუზერი ამ მეილით უკვე არსებობს");
            }
            
            if (Employeee == null)
            {
                ModelState.AddModelError("EmployeeEmail", "დასაქმებული ამ მეილით არ არსებობს");

            }
            
            else
            {
                employeeId = Employeee.ID;
            }
            if (ModelState.IsValid)
            {
                var newUser = new Model.Models.Users()
                {
                    
                    UserName = model.UserName,
                    PassWord = model.Password,
                    RegistrationDate = DateTime.Now,
                    IsActive = false,
                    EmployeeID = employeeId,
                    UserRoleTitle = model.UserRoleTitle,
                    Employees = Employeee
                };
                UsersService.CreateUser(newUser);
                UsersService.SaveUser();
                return RedirectToAction(nameof(HomeController.Index), "Home");

            }
            return View();

        }
        [HttpGet]
        public ActionResult View(int id)

        {
            var user = UsersService.GetUser(id);
            var AllEmployeeEmails = EmployeesService.GetEmployees();
            var Employeee = AllEmployeeEmails.FirstOrDefault(u => u.Email == user.Employees.Email);

           

            if (user != null)
            {
                var viewModel = new RegisterUserViewModel()
                {
                    ID = user.ID,
                    UserName = user.UserName,
                    Password = user.PassWord,
                    UserRoleTitle= user.UserRoleTitle,
                    Employees = Employeee
                    
                };
                return View("View", viewModel);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Submit(RegisterUserViewModel model)
        {
            var employee = EmployeesService.GetEmployee(model.Employees.ID);
            var user = UsersService.GetUser(model.ID);
            if (user != null)
            {
                user.UserName = model.UserName;
                user.PassWord = model.Password;
                user.UserRoleTitle = model.UserRoleTitle;
                UsersService.SaveUser();
            }
            if(employee  != null)
            {
                employee.FirstName = model.Employees.FirstName;
                EmployeesService.SaveEmployee();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(RegisterUserViewModel model)
        {
            var user = UsersService.GetUser(model.ID);
            if (user != null)
            {

                UsersService.DeleteUser(user);
                UsersService.SaveUser();

            }
            return RedirectToAction("Index");
        }
        public ActionResult Search(string searching)
        {
            List<Users> usersList = new List<Users>();

            //List<Model.Models.Users> usersList = new List<Model.Models.Users>();
            var users = UsersService.GetUsers().ToList();
            foreach (var item in users)
            {
                if (/*item.UserName.StartsWith(searching) || item.UserRoleTitle.StartsWith(searching) || item.PassWord.StartsWith(searching)*/(item?.UserName ?? null) != null && item.UserName.StartsWith(searching) || (item?.UserRoleTitle ?? null) != null && item.UserRoleTitle.StartsWith(searching) || (item?.PassWord ?? null) != null && item.PassWord.StartsWith(searching) )
                {
                    usersList.Add(item);
                }
            }

            return View(usersList);

        }
    }
}