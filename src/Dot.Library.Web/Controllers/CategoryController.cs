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
                Id=1,
                Name="Programowanie",
            },
            new Category()
            {
                Id=2,
                Name="Chemia",
            },
            new Category()
            {
                Id=3,
                Name="Rolnictwo",
            }
        };

        [HttpGet]
        public IEnumerable<Category> GetAll() => _categories;

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(long id)
        {
            var item = _categories.Find(t => t.Id == id);
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
            return CreatedAtRoute("GetById",new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Category category)
        {
            if(category == null || category.Id != id )
            {
                return BadRequest();
            }
            var wantedUser = _categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                
            }
            _categories[wantedUser.Id] = wantedUser;
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var delete = _categories.FirstOrDefault(t => t.Id == id);
            if(delete == null)
            {
                return NotFound();
            }

            _categories.RemoveAt(delete.Id);
            return new NoContentResult();
        }

      
    }
}