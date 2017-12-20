using Dot.Library.Database.Model;
using Dot.Library.Web.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> SearchByCategory(string name);
    }
}
