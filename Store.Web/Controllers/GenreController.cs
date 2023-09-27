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


namespace Store.Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly IUsersService UsersService;
        private readonly IGenresService GenresService;
        private readonly IRolesService RolesService;
        private readonly IAuthorsService AuthorsService;
        private readonly IPositionsService PositionsService;
        private readonly StoreSeedData _seedData;
        private readonly IEmployeesService EmployeesService;



        public GenreController(IUsersService UsersService,IGenresService GenresService, IAuthorsService AuthorsService ,IPositionsService PositionsService ,IEmployeesService EmployeesService, IRolesService RolesService)
        {
            this.GenresService = GenresService;
            this.AuthorsService = AuthorsService;
            this.UsersService = UsersService;
            this.PositionsService = PositionsService;
            this.RolesService = RolesService;
            this.EmployeesService = EmployeesService;
            _seedData = new StoreSeedData();
        }
        public ActionResult Index()
        {
            var Genres = GenresService.GetGenres().ToList();
            return View(Genres);
        }


        [HttpGet]
        public ActionResult RegisterGenre()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterGenre(RegisterGenreViewModel model)
        {
            var genre = new Genres()
            {

                Name = model.Name,
                CreateDate = DateTime.Now,
            };
            GenresService.CreateGenre(genre);
            GenresService.SaveGenre();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            var genre = GenresService.GetGenre(id);
            if (genre != null)
            {
                var viewModel = new RegisterGenreViewModel()
                {
                    Name = genre.Name,
                };

                return View("View", viewModel);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Submit(RegisterGenreViewModel model)
        {
            var genre = GenresService.GetGenre(model.ID);
            if (genre != null)
            {
                //employee.ID = model.ID;
                genre.Name = model.Name;
                GenresService.SaveGenre();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(RegisterGenreViewModel model)
        {
            var genre = GenresService.GetGenre(model.ID);
            if (genre != null)
            {

                GenresService.DeleteGenre(genre);
                GenresService.SaveGenre();

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Search(string searching)
        {
            List<Genres> genresList = new List<Genres>();
            var genres = GenresService.GetGenres().ToList();
            foreach (var item in genres)
            {
                if (/*item.Name.StartsWith(searching)*/(item?.Name ?? null) != null && item.Name.StartsWith(searching) )
                {
                    genresList.Add(item);
                }
            }


            return View(genresList);

        }
    }
}