using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class BookPublishersRepository : RepositoryBase<BookPublishers>, IBookPublishersRepository
    {
        public BookPublishersRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IBookPublishersRepository : IRepository<BookPublishers>
    {

    }
}
