using Dot.Library.Database.Model;
using Dot.Library.Database;
using Dot.Library.Web.DataContracts;
using Dot.Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {


        public AuthorRepository(LibraryContext context) : base(context)
        {
        }
        public IEnumerable<Author> SearchByAuthor(string name)
        {
            yield return _context.Set<Author>().Find(name);
        }
    }
}
