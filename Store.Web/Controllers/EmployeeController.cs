using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Ajax.Utilities;
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
using Roles = Store.Model.Models.Roles;

namespace Store.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUsersService UsersService;
        private readonly IRolesService RolesService;
        private readonly IPositionsService PositionsService;
        private readonly StoreSeedData _seedData;
        private readonly IEmployeesService EmployeesService;



        public EmployeeController(IUsersService UsersService,IPositionsService PositionsService ,IEmployeesService EmployeesService, IRolesService RolesService)
        {
            this.UsersService = UsersService;
            this.PositionsService = PositionsService;
            this.RolesService = RolesService;
            this.EmployeesService = EmployeesService;
            _seedData = new StoreSeedData();
        }
        public ActionResult Index()
        {
            var employees = EmployeesService.GetEmployees().ToList();
            return View(employees);
        }


        [HttpGet]
        public ActionResult RegisterEmployee()
        {
            List<Positions> positions = new List<Positions>();
            positions = PositionsService.GetPositions().ToList();

            RegisterEmployeeViewModel model = new RegisterEmployeeViewModel();
            model.Positions = positions;
            return View(model);
        }





        [HttpPost]
        public ActionResult RegisterEmployee(RegisterEmployeeViewModel model)
        {
            //string nm = "df";
            //List<Positions> positions = new List<Positions>();
            //foreach (var item in model.Positions)
            //{
            //    if (model.IsChecked == true)
            //    {
                    
            //        model.PositionID = item.ID;
            //        nm = item.PositionTitle;
            //        positions.Add(item);

            //    }
            //}
            var employee = new Employees()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                HireDate = model.HireDate,
                Sallary = model.Sallary,
                CreateDate = DateTime.Now,
                
            };
            EmployeesService.CreateEmployee(employee);
            EmployeesService.SaveEmployee();
            //return RedirectToAction(nameof(HomeController.Index), "Home");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            var employee = EmployeesService.GetEmployee(id);
            var user = UsersService.GetUserByEmail(employee.Email);
            if (employee != null)
            {
                var viewModel = new RegisterEmployeeViewModel()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address = employee.Address,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    Sallary = employee.Sallary,
                    PositionID = employee.PositionID,
                    User = user
                  
                };
             
                return View("View", viewModel );
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Submit(RegisterEmployeeViewModel model)
        {
            var employee = EmployeesService.GetEmployee(model.ID);
            if (employee != null)
            {
                //employee.ID = model.ID;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Address = model.Address;
                employee.Email = model.Email;
                employee.PhoneNumber = model.PhoneNumber;
                employee.HireDate = model.HireDate;
                employee.Sallary = model.Sallary;
                EmployeesService.SaveEmployee();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(RegisterEmployeeViewModel model)
        {
            var user = UsersService.GetUserByEmail(model.Email);
            var employee = EmployeesService.GetEmployee(model.ID);
            if (employee != null)
            {
               if(user != null)
                {
                    UsersService.DeleteUser(user);
                    UsersService.SaveUser();
                }
                EmployeesService.DeleteEmployee(employee);
                EmployeesService.SaveEmployee();
             
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Search(string searching)
        {
            List<Employees> employeeList = new List<Employees>();
            var employees = EmployeesService.GetEmployees().ToList();
            foreach (var item in employees)
            {
                if (item.FirstName.StartsWith(searching) || item.LastName.StartsWith(searching) || item.Email.StartsWith(searching) || item.PhoneNumber.StartsWith(searching))
                {
                    employeeList.Add(item);
                }
            }

          
            return View(employeeList);

        }
    }
}