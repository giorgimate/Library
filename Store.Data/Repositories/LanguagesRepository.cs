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
    public class LanguagesRepository : RepositoryBase<Languages>, ILanguagesRepository
    {
        public LanguagesRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public Languages GetLanguageByName(string Name)
        {
            var language = this.DbContext.Languages.Where(x => x.Language == Name).FirstOrDefault();
            return language;
        }
        public override void Update(Languages entity)
        {
            entity.ChangeDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface ILanguagesRepository : IRepository<Languages>
    {
        Languages GetLanguageByName(string GenreName);

    }
}
