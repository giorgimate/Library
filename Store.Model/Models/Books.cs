using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Edition { get; set; }
        public int PageNumber { get; set; }
        public int TotalCopies { get; set; }
        public int AvialableCopies { get; set; }
        public int ISBN { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual List<BookPublishers> BookPublishers { get; set; }
        public virtual List<BookLanguages> BookLanguages { get; set; }
        public virtual List<BookGenres> BookGenres { get; set; }
        public virtual List<BookAuthors> BookAuthors { get; set; }
        public virtual List<BookShalves> BookShalves { get; set; }
        public virtual List<Reservations> Reservations { get; set; }
        public virtual List<Loans> Loans { get; set; }

    }
}
