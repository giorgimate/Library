using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class UsersRepository : RepositoryBase<Users>, IUsersRepository
    {
        public UsersRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Users GetUserByEmployeeID(int EmployeeID)
        {
            var User = this.DbContext.Users.Where(c => c.EmployeeID == EmployeeID).FirstOrDefault();

            return User;
        }
        public Users GetUserByUserRoleID(int UserRoleID)
        {
            var User = this.DbContext.Users.Where(c => c.UserRoleID == UserRoleID).FirstOrDefault();

            return User;
        }
        public Users GetUserByUserName(string UserName)
        {
            var User = this.DbContext.Users.Where(c => c.UserName == UserName).FirstOrDefault();

            return User;
        }
        public Users GetUserByEmployeeEmail(string email)
        {
            var User = this.DbContext.Users.Where(c => c.Employees.Email == email).FirstOrDefault();

            return User;
        }
        public Users GetUserByUserRoleTitle(string UserRoleTitle)
        {
            var User = this.DbContext.Users.Where(c => c.UserRoleTitle == UserRoleTitle).FirstOrDefault();

            return User;
        }


        public override void Update(Users entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IUsersRepository : IRepository<Users>
    {
        Users GetUserByEmployeeID(int EmployeeID);
        Users GetUserByUserRoleID(int UserRoleID);
        Users GetUserByEmployeeEmail(string email);
        Users GetUserByUserName(string UserName);
        Users GetUserByUserRoleTitle(string UserRoleTitle);

    }
}
