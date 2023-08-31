using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class UserRoles
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public virtual Users Users { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
