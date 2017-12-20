using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Dot.Library.Database;
using Dot.Library.Database.Model;
using System.Linq;
using Dot.Library.Web.Repository;
using Dot.Library.Web.DataContracts;
using AutoMapper;


namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<AuthorDto> GetAll()
        {
            var usersList = _repository.GetAll();

            var users = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDto>>(usersList);

            return users;
        }

        [HttpGet("{id}", Name = "Id")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);
            var model = _mapper.Map<Author, AuthorDto>(item);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AuthorDto item)
        {
            var model = _mapper.Map<AuthorDto, Author>(item);
            if (model == null)
            {
                return BadRequest();
            }

            _repository.Insert(model);
            return CreatedAtRoute("GetById", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AuthorDto author)
        {
            var model = _mapper.Map<AuthorDto, Author>(author);
            if (author == null || author.Id != id)
            {
                return BadRequest();
            }
            _repository.Update(model);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(AuthorDto author)
        {
            var model = _mapper.Map<AuthorDto, Author>(author);
            _repository.Delete(model);
            return new NoContentResult();
        }


    }
}