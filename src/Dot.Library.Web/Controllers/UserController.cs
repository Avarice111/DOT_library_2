using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dot.Library.Database.Model;

namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IList<User> _users = new List<User>() { new User() {
           ID= 1,
           FirstName = "Janusz",
           LastName = "Koziol",
           Login = "Goracy_Was21",
           Password = "was321",
           Address = new Address("Poland", "Warsaw", "00-021", "Mazowieckie", "Praga", 11, 2)
        }, new User(){
           ID= 2,
           FirstName = "Kamil",
           LastName = "Buk",
           Login = "DrzewoZniszczeniah2o",
           Password = "woodlife",
           Adress = new Address ("Poland", "Warsaw", "00-321", "Mazowieckie", "Bielany", 100, 23)
        }};
        

        [HttpGet]
        public IEnumerable<User> GetAll() => _users;

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var person = _users.FirstOrDefault(x => x.ID == id);
            if (person == null)
            {
                return NotFound();
            }
            return new ObjectResult(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddUser([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _users.Add(user);
            return CreatedAtRoute("GetById", new { id = user.ID }, user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User user)
        {
            if (user == null || user.ID != id)
            {
                return BadRequest();
            }
            var searchedUser = _users.FirstOrDefault(x => x.ID == user.ID);
            if (searchedUser == null)
            {
                return NotFound();
            }
            _users.Remove(searchedUser);

            ///Dodać mapper gdy bedzie implementacja modelu User
            ///
            searchedUser.ID = user.ID;
            searchedUser.FirstName = user.FirstName;
            searchedUser.LastName = user.LastName;
            searchedUser.Login = user.Login;
            searchedUser.Password = user.Password;
            searchedUser.Adress = user.Adress;
            _users.Add(searchedUser);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedUser = _users.FirstOrDefault(x => x.ID == id);
            if (searchedUser == null)
            {
                return NotFound();
            }
            _users.Remove(searchedUser);
            return new NoContentResult();
        }
    }
}