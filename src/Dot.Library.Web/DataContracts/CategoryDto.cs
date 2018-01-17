using System.Collections.Generic;
using Dot.Library.Database.Model;

namespace Dot.Library.Web.DataContracts
{
    public class CategoryDto
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string ParentCategory {get; set;}
    }
}