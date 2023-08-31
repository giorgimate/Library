using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Reservations
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool ResrvationStatus { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Members Members { get; set; }  
        public Employees Employees { get; set; }
        public Books Books { get; set; }
    }
}
