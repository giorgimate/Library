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
    // operations you want to expose
    public interface IRolesService
    {
        IEnumerable<Roles> GetRoles(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Roles GetRole(int id);
        Roles GetRole(string name);
        //Employees GetEmployeeByEmail(string email);
        //Users GetUserByUsername(string username);
        //Users GetUserByPassword(string password);
        void CreateRole(Roles category);
        void SaveEmployee();
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
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}

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

        //public Employees GetUserByEmail(string email)
        //{
        //    var Employee = EmployeesRepository.GetEmployeeByFirstName(email);
        //    return Employee;
        //}
        public void CreateRole(Roles Role)
        {
            RolesRepository.Add(Role);
        }

        public void SaveRole()
        {
            unitOfWork.Commit();
        }

        //errors artyavs
        public void SaveEmployee()
        {
            throw new NotImplementedException();
        }


        //public Employees GetEmployeeByEmail(string email)
        //{
        //    throw new NotImplementedException();
        //}

        //public Users GetUserByUsername(string username)
        //{
        //    throw new NotImplementedException();
        //}

        //public Users GetUserByPassword(string password)
        //{
        //    throw new NotImplementedException();
        //}
    }

    #endregion
}