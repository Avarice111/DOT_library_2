using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dot.Library.Database.Model;
using Dot.Library.Web.DataContracts;

namespace Dot.Library.Web.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext (DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryContract> Category { get; set; }
    }
}
