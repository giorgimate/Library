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
    public class BookAuthorsRepository : RepositoryBase<BookAuthors>, IBookAuthorsRepository
    {
        public BookAuthorsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IBookAuthorsRepository : IRepository<BookAuthors>
    {

    }
}

