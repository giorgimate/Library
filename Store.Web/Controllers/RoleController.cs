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
using Roles = Store.Model.Models.Roles;
using System.Web.Security;
using System.Web.ApplicationServices;

namespace Store.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRolesService RolesService;
        private readonly StoreSeedData _seedData;



        public RoleController(IRolesService RolesService)
        {
            this.RolesService = RolesService;
            _seedData = new StoreSeedData();
        }
        public ActionResult Index()
        {
           var roles = RolesService.GetRoles().ToList();
            return View(roles);
        }


        [HttpGet]
        public ActionResult RegisterRole()
        {
            return View();
        }





        [HttpPost]
        public ActionResult RegisterRole(RegisterRoleViewModel model)
        {
            var role = new Roles()
            {
                RoleName = model.RoleName
                //CreateDate = DateTime.Now,

            };
            RolesService.CreateRole(role);
            RolesService.SaveRole();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            var role = RolesService.GetRole(id);
            if (role != null)
            {
                var viewModel = new RegisterRoleViewModel()
                {
                    RoleName = role.RoleName
                };

                return View("View", viewModel);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Submit(RegisterRoleViewModel model)
        {
            var role = RolesService.GetRole(model.ID);
            if (role != null)
            {
                role.RoleName = model.RoleName;
                RolesService.SaveRole();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(RegisterRoleViewModel model)
        {
            var role = RolesService.GetRole(model.ID);
            if (role != null)
            {

                RolesService.DeleteRole(role);
                RolesService.SaveRole();

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Search(string searching)
        {
            List<Roles> rolesList = new List<Roles>();
            var roles = RolesService.GetRoles().ToList();
            foreach (var item in roles)
            {
                if ((item?.RoleName ?? null) != null && item.RoleName.StartsWith(searching))
                {
                    rolesList.Add(item);
                }
            }


            return View(rolesList);

        }
    }
}