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
using Authors = Store.Model.Models.Authors;

namespace Store.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUsersService UsersService;
        private readonly IRolesService RolesService;
        private readonly IAuthorsService AuthorsService;
        private readonly IPositionsService PositionsService;
        private readonly StoreSeedData _seedData;
        private readonly IEmployeesService EmployeesService;



        public AuthorController(IUsersService UsersService,IAuthorsService AuthorsService ,IPositionsService PositionsService ,IEmployeesService EmployeesService, IRolesService RolesService)
        {
            this.AuthorsService = AuthorsService;
            this.UsersService = UsersService;
            this.PositionsService = PositionsService;
            this.RolesService = RolesService;
            this.EmployeesService = EmployeesService;
            _seedData = new StoreSeedData();
        }
        public ActionResult Index()
        {
            var authors = AuthorsService.GetAuthors().ToList();
            return View(authors);
        }


        [HttpGet]
        public ActionResult RegisterAuthor()
        {  
            return View();
        }





        [HttpPost]
        public ActionResult RegisterAuthor(RegisterAuthorViewModel model)
        {
            var author = new Authors()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                CreateDate = DateTime.Now,

            };
            AuthorsService.CreateAuthor(author);
            AuthorsService.SaveAuthor();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            var author = AuthorsService.GetAuthor(id);
            if (author != null)
            {
                var viewModel = new RegisterAuthorViewModel()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,                  
                };
             
                return View("View", viewModel );
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Submit(RegisterAuthorViewModel model)
        {
            var employee = AuthorsService.GetAuthor(model.ID);
            if (employee != null)
            {
                //employee.ID = model.ID;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                AuthorsService.SaveAuthor();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(RegisterAuthorViewModel model)
        {
            var author = AuthorsService.GetAuthor(model.ID);
            if (author != null)
            {
              
                AuthorsService.DeleteAuthor(author);
                AuthorsService.SaveAuthor();
             
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Search(string searching)
        {
            List<Authors> authorsList = new List<Authors>();
            var authors = AuthorsService.GetAuthors().ToList();
            foreach (var item in authors)
            {
                if (/*item.FirstName.StartsWith(searching) || item.LastName.StartsWith(searching)*/(item?.FirstName ?? null) != null && item.FirstName.StartsWith(searching) || (item?.LastName ?? null) != null && item.LastName.StartsWith(searching))
                {
                    authorsList.Add(item);
                }
            }

          
            return View(authorsList);

        }
    }
}