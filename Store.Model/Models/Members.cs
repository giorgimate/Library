using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.Models
{
    public class Members
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool ActiveStatus { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual List<Reservations> Reservations { get; set; }
        public virtual List<Penalties> Penalties { get; set; }
        public virtual List<Loans> Loans { get; set; }

    }
}
