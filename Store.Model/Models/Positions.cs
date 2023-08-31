using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Positions
    {
        public int ID { get; set; }
        public string PositionTitle { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual List<EmployeePositions> EmployeePositions { get; set; }



    }
}
