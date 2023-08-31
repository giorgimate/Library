using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Shalves
    {
        public int ID { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public string Shelf { get; set; }
        public string Section { get; set; }
        public string Row { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual List<BookShalves> BookShalves { get; set; }


    }
}
