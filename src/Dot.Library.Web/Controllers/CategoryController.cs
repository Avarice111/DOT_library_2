using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Dot.Library.Database.Model;
using System.Linq;
using Dot.Library.Web.Repository;
using Dot.Library.Web.DataContracts;

namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]") ]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<CategoryContract> GetAll() => _repository.GetAll();

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryContract item)
        {
            if(item==null)
            {
                return BadRequest();
            }
            _repository.Insert(item);
            return CreatedAtRoute("GetById",new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CategoryContract category)
        {
            if(category == null || category.Id != id )
            {
                return BadRequest();
            }

            _repository.Update(category);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(CategoryContract category)
        {
            _repository.Delete(category);
            return new NoContentResult();
        }

      
    }
}