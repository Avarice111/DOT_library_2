using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Dot.Library.Database.Model;
using System.Linq;
using Dot.Library.Web.Repository;
using Dot.Library.Web.DataContracts;
using AutoMapper;

namespace Dot.Library.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]") ]
    public class CategoryController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> GetAll()
        {
            var usersList = _repository.GetAll();

            var users = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto> >(usersList);

            return users;
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);
            var model = _mapper.Map<Category, CategoryDto>(item);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryDto item)
        {
            var model = _mapper.Map<CategoryDto, Category>(item);
            if (model==null)
            {
                return BadRequest();
            }
            
            _repository.Insert(model);
            return CreatedAtRoute("GetById",new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CategoryDto category)
        {
            var model = _mapper.Map<CategoryDto,Category>(category);
            if(category == null || category.Id != id )
            {
                return BadRequest();
            }
            _repository.Update(model);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(CategoryDto category)
        {
            var model = _mapper.Map<CategoryDto, Category>(category);
            _repository.Delete(model);
            return new NoContentResult();
        }

      
    }
}