using Dot.Library.Database.Model;
using Dot.Library.Web.DataContracts;
using Dot.Library.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Library.Database;

namespace Dot.Library.Web.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
  

        public OrderRepository(LibraryContext context) : base(context)
        {
        }
        public IEnumerable<Order> SearchByUser(long id)
        {
            yield return _context.Set<Order>().Find(id);
        }
    }
}
