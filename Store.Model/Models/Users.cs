using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Users
    {
        public int ID { get; set; }
        public int? EmployeeID { get; set; }
        public int? UserRoleID { get; set; }
        public string UserName { get; set; }
        
        public string PassWord { get; set; }
        public DateTime? LastLogin { get; set; }
        public string LoginLocation { get; set; }
        public string IPAdress { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool? IsActive { get; set; } = false;

        public string UserRoleTitle { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual List<Employees> EmployeesList { get; set; }
        public Employees Employees { get; set; }
        public  List <UserRoles> UserRoles { get; set; }
    }
}
