using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class ReservationsRepository : RepositoryBase<Reservations>, IReservationsRepository
    {
        public ReservationsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Reservations GetReservationsByBookID(int BookID)
        {
            var Reservation = this.DbContext.Reservations.Where(c => c.BookID == BookID).FirstOrDefault();

            return Reservation;
        }
        public Reservations GetReservationsByMemberID(int MemberID)
        {
            var Reservation = this.DbContext.Reservations.Where(c => c.MemberID == MemberID).FirstOrDefault();

            return Reservation;
        }
        public Reservations GetReservationsByResvationDate(DateTime ReservationDate)
        {
            var Reservation = this.DbContext.Reservations.Where(c => c.ReservationDate == ReservationDate).FirstOrDefault();

            return Reservation;
        }


        public override void Update(Reservations entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IReservationsRepository : IRepository<Reservations>
    {
        Reservations GetReservationsByBookID(int BookID);
        Reservations GetReservationsByMemberID(int MemberID);
        Reservations GetReservationsByResvationDate(DateTime ReservationDate);

    }
}
