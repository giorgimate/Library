using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service
{
    public interface IMenusService
    {
        //IEnumerable<Menu> GetMenu(string name = null);
        //IEnumerable<Users> GetUserName(string name );
       
        Menu GetMenu(string name);
     
        void CreateMenu(Menu category);
        void SaveMenu();
    }

    public class MenuService : IMenusService
    {
        private readonly IMenuRepository MenuRepository;
        private readonly IUnitOfWork unitOfWork;

        public MenuService(IMenuRepository MenuRepository, IUnitOfWork unitOfWork)
        {
            this.MenuRepository = MenuRepository;
            this.unitOfWork = unitOfWork;
        }
        

        #region ICategoryService Members
        public Menu GetMenu(string MenuName)
        {
            var Menu = MenuRepository.GetMenuByMenuName(MenuName);
            return Menu;
        }
        public void SaveMenu()
        {
            unitOfWork.Commit();
        }

        //public IEnumerable<Menu> GetMenu(string name = null)
        //{
        //    if (string.IsNullOrEmpty(name))
        //        return MenuRepository.GetAll();
        //    else
        //        return MenuRepository.GetAll().Where(c => c.MenuName == name);
        //}
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}





        public void CreateMenu(Menu Menu)
        {
            MenuRepository.Add(Menu);
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
