using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Service
{
    public interface IRolesService
    {
        IEnumerable<Roles> GetRoles(string name = null);
        Roles GetRole(int id);
        Roles GetRole(string name);
        void CreateRole(Roles name);
        void DeleteRole(Roles name);
        void SaveRole();
    }

    public class RolesService : IRolesService
    {
        private readonly IRolesRepository RolesRepository;
        private readonly IUnitOfWork unitOfWork;

        public RolesService(IRolesRepository RolesRepository, IUnitOfWork unitOfWork)
        {
            this.RolesRepository = RolesRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Roles> GetRoles(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return RolesRepository.GetAll();
            else
                return RolesRepository.GetAll().Where(c => c.RoleName == name);
        }

        public Roles GetRole(int id)
        {
            var Role = RolesRepository.GetById(id);
            return Role;
        }

        public Roles GetRole(string name)
        {
            var Role = RolesRepository.GetRoleByRoleName(name);
            return Role;
        }
        public void CreateRole(Roles Role)
        {
            RolesRepository.Add(Role);
        }
        public void DeleteRole(Roles Role)
        {
            RolesRepository.Delete(Role);
        }

        public void SaveRole()
        {
            unitOfWork.Commit();
        }



    }

    #endregion
}