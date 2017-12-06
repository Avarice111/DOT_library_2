using System;

namespace Dot.Library.Database
{
    public class Order
    {

        public int OrderId { get; set; }

        public DateTime Date { get; set; }

        public User User { get; set; }

        public List<Book> Books { get; set; }


    }
}