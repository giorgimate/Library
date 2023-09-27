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
using System.Web.ApplicationServices;
using DocumentFormat.OpenXml.EMMA;

namespace Store.Web.Controllers
{
    public class ShalveController : Controller
    {
        private readonly IShalvesService ShalvesService;
        private readonly StoreSeedData _seedData;



        public ShalveController(IShalvesService ShalvesService)
        {
            this.ShalvesService = ShalvesService;
            _seedData = new StoreSeedData();
        }
        public ActionResult Index()
        {
           var shalves = ShalvesService.GetShalves().ToList();
            return View(shalves);
        }


        [HttpGet]
        public ActionResult RegisterShalve()
        {
            return View();
        }





        [HttpPost]
        public ActionResult RegisterShalve(RegisterShalveViewModel model)
        {
            var shalve = new Shalves()
            {
                Floor = model.Floor,
                Room = model.Room,
                Shelf = model.Shelf,
                Section = model.Section,
                Row = model.Row,
                CreateDate = DateTime.Now

            };
            ShalvesService.CreateShalve(shalve);
            ShalvesService.SaveShalve();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            var shalve = ShalvesService.GetShalve(id);
            if (shalve != null)
            {
                var viewModel = new RegisterShalveViewModel()
                {
                    Floor = shalve.Floor,
                    Room = shalve.Room,
                    Shelf = shalve.Shelf,
                    Section = shalve.Section,
                    Row = shalve.Row,

                };

                return View("View", viewModel);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Submit(RegisterShalveViewModel model)
        {
            var shalve = ShalvesService.GetShalve(model.ID);
            if (shalve != null)
            {
                shalve.Floor = model.Floor;
                shalve.Room = model.Room;
                shalve.Shelf = model.Shelf;
                shalve.Section = model.Section;
                shalve.Row = model.Row;
                ShalvesService.SaveShalve();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(RegisterShalveViewModel model)
        {
            var shalve = ShalvesService.GetShalve(model.ID);
            if (shalve != null)
            {

                ShalvesService.DeleteShalve(shalve);
                ShalvesService.SaveShalve();

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Search(string searching)
        {
            List<Shalves> shalvesList = new List<Shalves>();
            var shalves = ShalvesService.GetShalves().ToList();
            foreach (var item in shalves)
            {
                //if ((item?.RoleName ?? null) != null && item.RoleName.StartsWith(searching))
                //{
                //    shalvesList.Add(item);
                //}
                if ((item?.Floor ?? null) != null && Convert.ToString(item.Floor).StartsWith(searching) || (item?.Room ?? null) != null && Convert.ToString(item.Room).StartsWith(searching) || (item?.Shelf ?? null) != null && item.Shelf.StartsWith(searching) || (item?.Section ?? null) != null && item.Section.StartsWith(searching) || (item?.Row ?? null) != null && item.Row.StartsWith(searching) )
                {
                    shalvesList.Add(item);
                }

            }


            return View(shalvesList);

        }
    }
}