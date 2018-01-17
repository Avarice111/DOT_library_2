using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web.DataContracts
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime Date {get; set;}
        public long userId { get; set; }
        public List<BookSummaryDto> Books {get; set;}
    }
}
