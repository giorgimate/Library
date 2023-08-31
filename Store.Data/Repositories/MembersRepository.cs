using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class MembersRepository : RepositoryBase<Members>, IMembersRepository
    {
        public MembersRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Members GetMembersByFirstName(string FirstName)
        {
            var Member = this.DbContext.Members.Where(c => c.FirstName == FirstName).FirstOrDefault();

            return Member;
        }
        public Members GetMembersByLastName(string LastName)
        {
            var Member = this.DbContext.Members.Where(c => c.FirstName == LastName).FirstOrDefault();

            return Member;
        }
        public Members GetMembersByEmail(string Email)
        {
            var Member = this.DbContext.Members.Where(c => c.Email == Email).FirstOrDefault();

            return Member;
        }
        public Members GetMembersByPhoneNumber(string PhoneNumber)
        {
            var Member = this.DbContext.Members.Where(c => c.PhoneNumber == PhoneNumber).FirstOrDefault();

            return Member;
        }


        public override void Update(Members entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IMembersRepository : IRepository<Members>
    {
        Members GetMembersByFirstName(string FirstName);
        Members GetMembersByLastName(string LastName);
        Members GetMembersByEmail(string Email);
        Members GetMembersByPhoneNumber(string PhoneNumber);



    }
}
