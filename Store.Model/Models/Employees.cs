using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Employees
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public int PositionID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public int Sallary { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Users Users { get; set; }
        public virtual List<EmployeePositions> EmployeePositions { get; set; }
        public EmployeePositions EmployeePositionsList { get; set; }
        public virtual List<Users> UsersList { get; set; }
        public virtual List<Reservations> Reservations { get; set; }
    }

}
