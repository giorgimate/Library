using Store.Data.Infrastructure;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class EmployeePositionsRepository : RepositoryBase<EmployeePositions>, IEmployeePositionsRepository
    {
        public EmployeePositionsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IEmployeePositionsRepository : IRepository<EmployeePositions>
    {

    }
}
