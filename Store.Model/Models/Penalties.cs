using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Penalties
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public int LoanID { get; set; }
        public DateTime PenaltyDate { get; set; }
        public double PenaltyAmount { get; set; }
        public string    MyProperty { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Loans Loans { get; set; }
        public Members Members { get; set; }
    }
}
