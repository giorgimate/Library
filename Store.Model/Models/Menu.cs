using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Menu
    {
        public int ID { get; set; }
        
        public string MenuName { get; set; }
        public List<RoleMenu> RoleMenus { get; set; }
        public int ParrentMenuItemID { get; set; }
        public string url { get; set; }
    }
}
