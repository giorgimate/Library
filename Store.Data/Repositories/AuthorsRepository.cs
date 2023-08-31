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
    public class AuthorsRepository : RepositoryBase<Authors>, IAuthorsRepository
    {
        public AuthorsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Authors GetAuthorByFirstname(string AuthorName)
        {
            var Author = this.DbContext.Authors.Where(c => c.FirstName == AuthorName).FirstOrDefault();

            return Author;
        }
        public Authors GetAuthorByLastname(string AuthorLastName)
        {
            var Author = this.DbContext.Authors.Where(c => c.LastName == AuthorLastName).FirstOrDefault();

            return Author;
        }

        public override void Update(Authors entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IAuthorsRepository : IRepository<Authors>
    {
        Authors GetAuthorByFirstname(string AuthorName);
        Authors GetAuthorByLastname(string AuthorLastName);
    }
}
