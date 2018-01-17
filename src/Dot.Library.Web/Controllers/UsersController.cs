using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dot.Library.Database;
using Dot.Library.Web.DataContracts;
using Dot.Library.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dot.Library.Web.Controllers
{
    [Consumes("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        LibraryContext _libraryContext;

        public UsersController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _libraryContext.Users.ToList();
            return Json(users.Select(user => new UserDto
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password
            }));
        }
        // POST api/<controller>
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult AddUser([FromBody]UserDto user)
        {
            _libraryContext.Users.Add(new Database.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password

            });
            _libraryContext.SaveChanges();
            return NoContent();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
