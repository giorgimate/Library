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
    public class LanguageController : Controller
    {
        private readonly ILanguagesService languagesService;
        private readonly StoreSeedData _seedData;



        public LanguageController(ILanguagesService languagesService)
        {
            this.languagesService = languagesService;
            _seedData = new StoreSeedData();
        }
        public ActionResult Index()
        {
            var languages = languagesService.GetLanguages().ToList();
            return View(languages);
        }


        [HttpGet]
        public ActionResult RegisterLanguage()
        {  
            return View();
        }





        [HttpPost]
        public ActionResult RegisterLanguage(RegisterLanguageViewModel model)
        {
            var alllanguages = languagesService.GetLanguages().ToList();
            foreach (var lang in alllanguages)
            {
                if (model.Language == lang.Language)
                {
                    ModelState.AddModelError("UniqueLanguage", "ასეთი ენა უკვე არსებობს");
                }
            }
            if (ModelState.IsValid)
            {


                var language = new Languages()
                {

                    Language = model.Language,
                    CreateDate = DateTime.Now,

                };
                languagesService.CreateLanguage(language);
                languagesService.SaveLanguage();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            var language = languagesService.GetLanguage(id);
            if (language != null)
            {
                var viewModel = new RegisterLanguageViewModel()
                {
                    Language = language.Language
                };

                return View("View", viewModel);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Submit(RegisterLanguageViewModel model)
        {

            var alllanguages = languagesService.GetLanguages().ToList();
            foreach (var lang in alllanguages)
            {
                if (model.Language == lang.Language)
                {
                    ModelState.AddModelError("UniqueLanguage", "ასეთი ენა უკვე არსებობს");
                }
            }
            if (ModelState.IsValid)
            {


                var language = languagesService.GetLanguage(model.ID);
                if (language != null)
                {
                    //employee.ID = model.ID;
                    language.Language = model.Language;
                    languagesService.SaveLanguage();
                }
                return RedirectToAction("Index");
            }
            return View("View", model);
        }
        [HttpPost]
        public ActionResult Delete(RegisterLanguageViewModel model)
        {
            var language = languagesService.GetLanguage(model.ID);
            if (language != null)
            {

                languagesService.DeleteLanguage(language);
                languagesService.SaveLanguage();

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Search(string searching)
        {
            List<Languages> languagesList = new List<Languages>();
            var languages = languagesService.GetLanguages().ToList();
            foreach (var item in languages)
            {
                if (/*item.FirstName.StartsWith(searching) || item.LastName.StartsWith(searching)*/(item?.Language ?? null) != null && item.Language.StartsWith(searching))
                {
                    languagesList.Add(item);
                }
            }


            return View(languagesList);

        }
    }
}