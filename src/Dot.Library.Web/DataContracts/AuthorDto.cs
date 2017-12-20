using System.Collections.Generic;
using Dot.Library.Database;

namespace Dot.Library.Web.DataContracts
{
    public class AuthorDto
      
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public List<Book> Books { get; set; }

    }
}