using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    
        public class RolesRepository : RepositoryBase<Roles>, IRolesRepository
        {
            public RolesRepository(IDbFactory dbFactory)
                : base(dbFactory) { }

           
           
            public Roles GetRoleByRoleName(string RoleName)
            {
                var Role = this.DbContext.Roles.Where(c => c.RoleName == RoleName).FirstOrDefault();

                return Role;
            }
          

            //public override void Update(Roles entity)
            //{
            //    entity.ChangeDate = DateTime.Now;
            //    base.Update(entity);
            //}
        }

        public interface IRolesRepository : IRepository<Roles>
        {
          
            Roles GetRoleByRoleName(string RoleName);
            

        }
    
}
