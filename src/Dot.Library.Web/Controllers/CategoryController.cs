using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Dot.Library.Database.Model;
using System.Linq;

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

        [HttpGet("{id}", Name = "GetById")]
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
            return CreatedAtRoute("GetById",new {id = item.ID}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Category category)
        {
            if(category == null || category.ID != id )
            {
                return BadRequest();
            }
            var wantedUser = _categories.FirstOrDefault(x => x.ID == id);
            if (category == null)
            {
                
            }
            _categories[wantedUser.ID] = wantedUser;
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var delete = _categories.FirstOrDefault(t => t.ID == id);
            if(delete == null)
            {
                return NotFound();
            }

            _categories.RemoveAt(delete.ID);
            return new NoContentResult();
        }

      
    }
}