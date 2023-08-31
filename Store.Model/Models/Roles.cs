using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Roles
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public List<UserRoles> UserRoles { get; set; }
        public List<RoleMenu> RoleMenu { get; set; }
    }
}
