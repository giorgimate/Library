using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service
{
    // operations you want to expose
    public interface IRoleMenuService
    {
        IEnumerable<RoleMenu> GetRoleMenus(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        RoleMenu GetRoleMenu(int id);
        //RoleMenu GetUser(string name);
        //Users GetUserByEmail(string email);
        RoleMenu GetRoleMenuByRoleID(int id);
        RoleMenu GetRoleMenuByMenuID(int id);
        void CreateRoleMenu(RoleMenu category);
        void SaveRoleMenu();
    }

    public class RoleMenuService : IRoleMenuService
    {
        private readonly IRoleMenuRepository RoleMenuRepository;
        private readonly IUnitOfWork unitOfWork;

        public RoleMenuService(IRoleMenuRepository RoleMenuRepository, IUnitOfWork unitOfWork)
        {
            this.RoleMenuRepository = RoleMenuRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<RoleMenu> GetRoleMenus(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return RoleMenuRepository.GetAll();
            else
                return RoleMenuRepository.GetAll();
        }


        public RoleMenu GetRoleMenu(int id)
        {
            var User = RoleMenuRepository.GetById(id);
            return User;
        }

        public RoleMenu GetRoleMenuByRoleID(int id)
        {
            var rolemenu = RoleMenuRepository.GetRoleByRoleID(id);
            return rolemenu;
        }
        public RoleMenu GetRoleMenuByMenuID(int id)
        {
            var rolemenu = RoleMenuRepository.GetRoleByMenuID(id);
            return rolemenu;
        }


        public void CreateRoleMenu(RoleMenu rolemenu)
        {
            RoleMenuRepository.Add(rolemenu);
        }

        public void SaveRoleMenu()
        {
            unitOfWork.Commit();
        }
    }
    }

    #endregion

