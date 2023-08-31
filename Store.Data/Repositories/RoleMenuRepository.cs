using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class RoleMEnuRepository : RepositoryBase<RoleMenu>, IRoleMenuRepository
    {
        public RoleMEnuRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        //public RoleMenu GetRoleByID(int id)
        //{
        //    var rolemenu = this.DbContext.RoleMenu.Where(c => c.ID == id).FirstOrDefault();

        //    return rolemenu;
        //}
        public RoleMenu GetRoleByRoleID(int id)
        {
            var rolemenu = this.DbContext.RoleMenu.Where(c => c.RoleID == id).FirstOrDefault();

            return rolemenu;
        }
        public RoleMenu GetRoleByMenuID(int id)
        {
            var rolemenu = this.DbContext.RoleMenu.Where(c => c.MenuID == id).FirstOrDefault();

            return rolemenu;
        }

      
    }

    public interface IRoleMenuRepository : IRepository<RoleMenu>
    {
        //RoleMenu GetRoleByID(int id);
        RoleMenu GetRoleByRoleID(int id);
        RoleMenu GetRoleByMenuID(int id);

    }
}
