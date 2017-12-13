using System.Collections.Generic;
namespace Dot.Library.Database.Model
{
    public class Category
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public List<Category> subCategories {get; set;}
        public Category ParentCategory {get; set;}
    }
}