using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Loans
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int OverDueDays { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Books Books { get; set; }
        public Members Members { get; set; }
        public virtual List<Penalties> Penalties { get; set; }

    }
}
