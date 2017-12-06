using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dot.Library.Database.Model;

namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        // GET api/values/
        [HttpPost]
        public IActionResult Create()
        {
           
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update()
        {
         return "id"
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete())
        {
            
        }
    }
}