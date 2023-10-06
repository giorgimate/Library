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
    public class PublisherController : Controller
    {
        private readonly IPublishersService PublishersService;
        private readonly StoreSeedData _seedData;



        public PublisherController(IPublishersService PublishersService )
        {
            this.PublishersService = PublishersService;
            _seedData = new StoreSeedData();
        }
        public ActionResult Index()
        {
           var publishers = PublishersService.GetPublishers().ToList();
            return View(publishers);
        }


        [HttpGet]
        public ActionResult RegisterPublisher()
        {
            return View();
        }





        [HttpPost]
        public ActionResult RegisterPublisher(RegisterPublisherViewModel model)
        {
            var allpublisher = PublishersService.GetPublishers().ToList();
            foreach (var publisher in allpublisher)
            {
                if (model.Name == publisher.Name && model.Address == publisher.Address && model.PhoneNumber == publisher.PhoneNumber && model.Email == publisher.Email)
                {
                    ModelState.AddModelError("UniquePublisher", "ასეთი გამომცემლობა უკვე არსებობს");
                }
            }
            if (ModelState.IsValid)
            {


                var publisher = new Publishers()
                {

                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    CreateDate = DateTime.Now,

                };
                PublishersService.CreatePublisher(publisher);
                PublishersService.SavePublisher();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            var publisher = PublishersService.GetPublisher(id);
            if (publisher != null)
            {
                var viewModel = new RegisterPublisherViewModel()
                {
                    Name = publisher.Name,
                    Address = publisher.Address,
                    PhoneNumber = publisher.PhoneNumber,
                    Email = publisher.Email,
                    
                };

                return View("View", viewModel);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Submit(RegisterPublisherViewModel model)
        {
             var allpublisher = PublishersService.GetPublishers().ToList();
            foreach (var publisher in allpublisher)
            {
                if (model.Name == publisher.Name && model.Address == publisher.Address && model.PhoneNumber == publisher.PhoneNumber && model.Email == publisher.Email)
                {
                    ModelState.AddModelError("UniquePublisher", "ასეთი გამომცემლობა უკვე არსებობს");
                }
            }
            var Publisher = PublishersService.GetPublisher(model.ID);
            if (ModelState.IsValid)
            {


                if (Publisher != null)
                {
                    Publisher.Name = model.Name;
                    Publisher.Address = model.Address;
                    Publisher.PhoneNumber = model.PhoneNumber;
                    Publisher.Email = model.Email;
                    PublishersService.SavePublisher();
                }
                return RedirectToAction("Index");
            }
            return View("View", model);
        }
        [HttpPost]
        public ActionResult Delete(RegisterPublisherViewModel model)
        {
            var publisher = PublishersService.GetPublisher(model.ID);
            if (publisher != null)
            {

                PublishersService.DeletePublisher(publisher);
                PublishersService.SavePublisher();

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Search(string searching)
        {
            List<Publishers> publishersList = new List<Publishers>();
            var publishers = PublishersService.GetPublishers().ToList();
            foreach (var item in publishers)
            {
                if ((item?.Name ?? null) != null && item.Name.StartsWith(searching) || (item?.Address ?? null) != null && item.Address.StartsWith(searching) || (item?.PhoneNumber ?? null) != null && item.PhoneNumber.StartsWith(searching) || (item?.Email ?? null) != null && item.Email.StartsWith(searching))
                {
                    publishersList.Add(item);
                }
            }


            return View(publishersList);

        }
    }
}