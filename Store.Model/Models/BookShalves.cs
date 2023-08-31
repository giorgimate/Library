using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class BookShalves
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int ShelfID { get; set; }
        public int BookQuantity { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Books Books { get; set; }
        public Shalves Shalves { get; set; }
    }
}
