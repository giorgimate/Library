using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class PublishersRepository : RepositoryBase<Publishers>, IPublishersRepository
    {
        public PublishersRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Publishers GetPublishersByName(string Name)
        {
            var Publisher = this.DbContext.Publishers.Where(c => c.Name == Name).FirstOrDefault();

            return Publisher;
        }
        public Publishers GetPublishersByEmail(string Email)
        {
            var Publisher = this.DbContext.Publishers.Where(c => c.Email == Email).FirstOrDefault();

            return Publisher;
        }
        public Publishers GetMembersByPhoneNumber(string PhoneNumber)
        {
            var Publisher = this.DbContext.Publishers.Where(c => c.PhoneNumber == PhoneNumber).FirstOrDefault();

            return Publisher;
        }


        public override void Update(Publishers entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IPublishersRepository : IRepository<Publishers>
    {
        Publishers GetPublishersByName(string FirstName);
        Publishers GetPublishersByEmail(string Email);
        Publishers GetMembersByPhoneNumber(string PhoneNumber);



    }
}
