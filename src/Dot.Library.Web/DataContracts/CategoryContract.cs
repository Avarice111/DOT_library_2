using System.Collections.Generic;
using Dot.Library.Database.Model;

namespace Dot.Library.Web.DataContracts
{
    public class CategoryContract
    {
          public int Id {get; set;}
        public string Name {get; set;}
        public List<Category> subCategories {get; set;}
        public Category ParentCategory {get; set;}
    }
}