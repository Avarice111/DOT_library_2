using Dot.Library.Database;
using Dot.Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(LibraryContext _context) : base(_context)
        {
        }
    }
}
