using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class BooksRepository : RepositoryBase<Books>, IBooksRepository
    {
        public BooksRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Books GetBookByName(string BookName)
        {
            var Book = this.DbContext.Books.Where(c => c.Title == BookName).FirstOrDefault();

            return Book;
        }
        

        public override void Update(Books entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IBooksRepository : IRepository<Books>
    {
        Books GetBookByName(string AuthorName);
     
    }
}
