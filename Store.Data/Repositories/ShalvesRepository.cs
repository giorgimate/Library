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
    public class ShalvesRepository : RepositoryBase<Shalves>, IShalvesRepository
    {
        public ShalvesRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IShalvesRepository : IRepository<Shalves>
    {
        ////Roles GetShalveByRoleName(string RoleName);

    }
}
