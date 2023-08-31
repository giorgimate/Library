using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class EmployeePositions
    {
        public int ID { get; set; }
        public int PositionID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Positions Positions { get; set; }
        public virtual List<Employees> Employees { get; set; }

    }
}
