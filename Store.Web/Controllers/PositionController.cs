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
    public class PositionController : Controller
    {
        private readonly IPositionsService PositionsService;
        private readonly StoreSeedData _seedData;



        public PositionController(IPositionsService PositionsService)
        {
            this.PositionsService = PositionsService;
            _seedData = new StoreSeedData();
        }
        public ActionResult Index()
        {
           var positions = PositionsService.GetPositions().ToList();
            return View(positions);
        }


        [HttpGet]
        public ActionResult RegisterPosition()
        {
            return View();
        }





        [HttpPost]
        public ActionResult RegisterPosition(RegisterPositonViewModel model)
        {

            var allposition = PositionsService.GetPositions().ToList();
            foreach (var position in allposition)
            {
                if (model.PositionTitle == position.PositionTitle)
                {
                    ModelState.AddModelError("UniquePosition", "ასეთი პოზიცია უკვე არსებობს");
                }
            }
            if (ModelState.IsValid)
            {


                var position = new Positions()
                {

                    PositionTitle = model.PositionTitle,
                    CreateDate = DateTime.Now,

                };
                PositionsService.CreatePosition(position);
                PositionsService.SavePosition();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            var position = PositionsService.GetPositionByID(id);
            if (position != null)
            {
                var viewModel = new RegisterPositonViewModel()
                {
                    PositionTitle = position.PositionTitle
                };

                return View("View", viewModel);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Submit(RegisterPositonViewModel model)
        {
            var allposition = PositionsService.GetPositions().ToList();
            foreach (var pos in allposition)
            {
                if (model.PositionTitle == pos.PositionTitle)
                {
                    ModelState.AddModelError("UniquePosition", "ასეთი პოზიცია უკვე არსებობს");
                }
            }
            if (ModelState.IsValid)
            {


                var position = PositionsService.GetPositionByID(model.ID);
                if (position != null)
                {
                    position.PositionTitle = model.PositionTitle;
                    PositionsService.SavePosition();
                }
                return RedirectToAction("Index");
            }
            return View("View", model);
        }
        [HttpPost]
        public ActionResult Delete(RegisterPositonViewModel model)
        {
            var position = PositionsService.GetPositionByID(model.ID);
            if (position != null)
            {

                PositionsService.DeletePosition(position);
                PositionsService.SavePosition();

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Search(string searching)
        {
            List<Positions> positionsList = new List<Positions>();
            var positions = PositionsService.GetPositions().ToList();
            foreach (var item in positions)
            {
                if ((item?.PositionTitle ?? null) != null && item.PositionTitle.StartsWith(searching) )
                {
                    positionsList.Add(item);
                }
            }


            return View(positionsList);

        }
    }
}