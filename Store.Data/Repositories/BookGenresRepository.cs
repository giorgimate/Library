using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class BookGenressRepository : RepositoryBase<BookGenres>, IBookGenresRepository
    {
        public BookGenressRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IBookGenresRepository : IRepository<BookGenres>
    {

    }
}
