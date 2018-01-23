using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dot.Library.Web.Repository;
using Dot.Library.Web.DataContracts;
using Microsoft.AspNetCore.Mvc;
using Dot.Library.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dot.Library.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserController(IMapper mapper, IUserRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            var userList = _repository.GetAll();
            var users = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(userList);

            return users;
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);

            var model = _mapper.Map<User, UserDto>(item);

            if (item == null)
            {
                return NotFound();
            }
            return new JsonResult(model);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody] UserDto item)
        {
            var model = _mapper.Map<UserDto, User>(item);

            if (model == null)
            {
                return BadRequest();
            }

            _repository.Insert(model);
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto user)
        {
            var model = _mapper.Map<UserDto, User>(user);
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }
            _repository.Update(model);
            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(UserDto user)
        {
            var model = _mapper.Map<UserDto, User>(user);
            _repository.Delete(model);
            return new NoContentResult();
        }
    }
}
