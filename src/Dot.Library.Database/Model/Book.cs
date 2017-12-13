using System;

namespace Dot.Library.Database
{

public class Book
    {
      public int BookId { get; set; }

      public string Title { get; set; }
        
      public string Cover { get; set; }

      public string Description { get; set; }

      public Author Author { get; set; }

      public Book linkedBooks { get; set; }

      public bool Availability { get; set; }
    }
}