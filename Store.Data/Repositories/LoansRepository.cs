using Store.Data.Infrastructure;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class LoansRepository : RepositoryBase<Loans>, ILoansRepository
    {
        public LoansRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Loans GetLoanByBookID(int LoanBookID)
        {
            var LoanBook = this.DbContext.Loans.Where(c => c.BookID == LoanBookID).FirstOrDefault();

            return LoanBook;
        }
        public Loans GetLoanByMemberID(int LoanMemberID)
        {
            var LoanBook = this.DbContext.Loans.Where(c => c.MemberID == LoanMemberID).FirstOrDefault();

            return LoanBook;
        }

        public override void Update(Loans entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface ILoansRepository : IRepository<Loans>
    {
        Loans GetLoanByBookID(int LoanBookID);
        Loans GetLoanByMemberID(int LoanMemberID);
    }
}
