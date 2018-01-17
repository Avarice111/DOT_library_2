using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web.DataContracts
{
    public class MessageDto
    {
        public int Id { get; set; }

        public string Author { get; set; }
        public string imgUrl { get; set; }
        public DateTime Date {get; set;}
        public string Text { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
