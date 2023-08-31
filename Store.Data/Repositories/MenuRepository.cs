using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory)
            : base(dbFactory) { }



        public Menu GetMenuByMenuName(string MenuName)
        {
            var Menu = this.DbContext.menus.Where(c => c.MenuName == MenuName).FirstOrDefault();

            return Menu;
        }


        //public override void Update(Menu entity)
        //{
        //    entity.ChangeDate = DateTime.Now;
        //    base.Update(entity);
        //}
    }

    public interface IMenuRepository : IRepository<Menu>
    {

        Menu GetMenuByMenuName(string MenuName);


    }
}
