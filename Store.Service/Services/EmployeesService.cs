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
    public interface IEmployeesService
    {
        IEnumerable<Employees> GetEmployees(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Employees GetEmployee(int id);
        Employees GetEmployee(string name);
        Employees GetEmployeeByEmail(string email);
        //Users GetUserByUsername(string username);
        //Users GetUserByPassword(string password);
        void DeleteEmployee(Employees employees);
        void CreateEmployee(Employees category);
        void SaveEmployee();
    }

    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository EmployeesRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeesService(IEmployeesRepository EmployeesRepository, IUnitOfWork unitOfWork)
        {
            this.EmployeesRepository = EmployeesRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members
        
        public IEnumerable<Employees> GetEmployees(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return EmployeesRepository.GetAll();
            else
                return EmployeesRepository.GetAll().Where(c => c.FirstName == name);
        }
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}

        public Employees GetEmployee(int id)
        {
            var Employee = EmployeesRepository.GetById(id);
            return Employee;
        }

        public Employees GetEmployee(string name)
        {
            var Employee = EmployeesRepository.GetEmployeeByFirstName(name);
            return Employee;
        }

        public Employees GetEmployeeByEmail(string email)
        {
            var Employee = EmployeesRepository.GetEmployeeByEmail(email);
            return Employee;
        }
        public void CreateEmployee(Employees employee)
        {
            EmployeesRepository.Add(employee);
        }
        public void DeleteEmployee(Employees employees)
        {
            EmployeesRepository.Delete(employees);
        }
        public void SaveEmployee()
        {
            unitOfWork.Commit();
        }




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