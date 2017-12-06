using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> GetValues()
        {
            return new string[] { "value1", "value2" };
        }
        
        [Route("{id}")]
        [HttpGet]
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    [Route("api/[controller=Notification]")]
    public class NotificationsController: Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Notification> GetValues()
        {
            return new Notification(){id=1;value=1};
        }
        
        [Route("{id}")]
        [HttpGet]
        public string GetById(int id)
        {
           return new Notification(){id=1;value=1};
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/valuess/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
