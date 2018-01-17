

using Dot.Library.Database.Model;
using Dot.Library.Web.Models;

namespace Dot.Library.Web.Repository
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(LibraryContext _context) : base(_context)
        {
        }
    }
}