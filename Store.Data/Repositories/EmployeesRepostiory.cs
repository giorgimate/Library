using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class EmployeesRepository : RepositoryBase<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Employees GetEmployeeByUserID(int EmployeeUserID)
        {
            var Employee = this.DbContext.Employees.Where(c => c.UserID == EmployeeUserID).FirstOrDefault();

            return Employee;
        }
        public Employees GetEmployeeByPositionID(int PositionID)
        {
            var Employee = this.DbContext.Employees.Where(c => c.PositionID == PositionID).FirstOrDefault();

            return Employee;
        }
        public Employees GetEmployeeByFirstName(string EmployeeFirstName)
        {
            var Employee = this.DbContext.Employees.Where(c => c.FirstName == EmployeeFirstName).FirstOrDefault();
            return Employee;
        }
        public Employees GetEmployeeByLastName(string EmployeeLastName)
        {
            var Employee = this.DbContext.Employees.Where(c => c.LastName == EmployeeLastName).FirstOrDefault();
            return Employee;
        }
        public Employees GetEmployeeByPhoneNumber(string EmployeePhoneNumber)
        {
            var Employee = this.DbContext.Employees.Where(c => c.PhoneNumber == EmployeePhoneNumber).FirstOrDefault();
            return Employee;
        }
        public Employees GetEmployeeByEmail(string EmployeeEmail)
        {
            var Employee = this.DbContext.Employees.Where(c => c.Email == EmployeeEmail).FirstOrDefault();
            return Employee;
        }
        public override void Update(Employees entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
        }

        public interface IEmployeesRepository : IRepository<Employees>
        {
            Employees GetEmployeeByUserID(int EmployeeUserID);
            Employees GetEmployeeByPositionID(int PositionID);
            Employees GetEmployeeByLastName(string EmployeeLastName);
            Employees GetEmployeeByFirstName(string EmployeeFirstName);
            Employees GetEmployeeByPhoneNumber(string EmployeePhoneNumber);
            Employees GetEmployeeByEmail(string EmployeeEmail);




        }
    
}