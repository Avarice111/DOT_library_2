using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Dot.Library.Database.Model;

namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]") ]
    public class CategoryController : Controller
    {
        public List<Category> _categories = new List<Category>{
            new Category()
            {
                ID=1,
                Name="Programowanie",
            },
            new Category()
            {
                ID=2,
                Name="Chemia",
            },
            new Category()
            {
                ID=3,
                Name="Rolnictwo",
            }
        };

        [HttpGet]
        public IEnumerable<Category> GetAll() => _categories;

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var item = _categories.Find(t => t.ID == id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category item)
        {
            if(item==null)
            {
                return BadRequest();
            }
            _categories.Add(item);
            return CreatedAtRoute(new {id = item.ID}, item);
        }
      
    }
}