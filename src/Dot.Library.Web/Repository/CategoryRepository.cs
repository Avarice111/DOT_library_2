using Dot.Library.Database.Model;
using Dot.Library.Web.DataContracts;
using Dot.Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
  

        public CategoryRepository(LibraryContext context) : base(context)
        {
        }
        public IEnumerable<Category> SearchByCategory(string name)
        {
            yield return _context.Set<Category>().Find(name);
        }
    }
}
