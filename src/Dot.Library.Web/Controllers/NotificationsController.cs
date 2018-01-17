using AutoMapper;
using Dot.Library.Database;
using Dot.Library.Web.DataContracts;
using Dot.Library.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Library.Database.Model;
using Dot.Library.Web.Models;

namespace Dot.Library.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class NotificationController : Controller
    {

        private readonly IMapper _mapper;
        private readonly INotificationRepository _repository;

        public NotificationController(INotificationRepository repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<NotificationDto> GetAll()
        {
            var notifList = _repository.GetAll();

            var notif = _mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationDto> >(notifList);

            return notif;
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);
            var model = _mapper.Map<Notification, NotificationDto>(item);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NotificationDto item)
        {
            var model = _mapper.Map<NotificationDto, Notification>(item);
            if (model==null)
            {
                return BadRequest();
            }
            
            _repository.Insert(model);
            return CreatedAtRoute("GetById",new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]NotificationDto noitifcation)
        {
            var model = _mapper.Map<NotificationDto,Notification>(noitifcation);
            if(noitifcation == null || noitifcation.Id != id )
            {
                return BadRequest();
            }
            _repository.Update(model);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(NotificationDto notification)
        {
            var model = _mapper.Map<NotificationDto, Notification>(notification);
            _repository.Delete(model);
            return new NoContentResult();
        }
        
    }
    
    // none
}