using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class RoleMenu
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int MenuID { get; set; }
        public Roles Roles { get; set; }
        public Menu Menu { get; set; }
    }
}
