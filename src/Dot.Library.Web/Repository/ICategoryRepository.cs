using Dot.Library.Web.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web.Repository
{
    public interface ICategoryRepository : IRepository<CategoryContract>
    {
        IEnumerable<CategoryContract> SearchByCategory(string name);
    }
}
