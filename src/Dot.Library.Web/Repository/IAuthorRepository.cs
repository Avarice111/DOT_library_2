using Dot.Library.Database;
using Dot.Library.Web.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web.Repository
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> SearchByAuthor(string name);
    }
}