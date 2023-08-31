using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class PenaltiesRepository : RepositoryBase<Penalties>, IPenaltiesRepository
    {
        public PenaltiesRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Penalties GetPenaltyByMemberID(int MemberID)
        {
            var Penalty = this.DbContext.Penalties.Where(c => c.MemberID == MemberID).FirstOrDefault();

            return Penalty;
        }
        public Penalties GetPenaltyByLoanID(int LoanID)
        {
            var Penalty = this.DbContext.Penalties.Where(c => c.LoanID == LoanID).FirstOrDefault();

            return Penalty;
        }


        public override void Update(Penalties entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IPenaltiesRepository : IRepository<Penalties>
    {
        Penalties GetPenaltyByMemberID(int MemberID);
        Penalties GetPenaltyByLoanID(int LoanID);



    }
}
