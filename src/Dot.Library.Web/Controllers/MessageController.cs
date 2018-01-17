using AutoMapper;
using Dot.Library.Database;
using Dot.Library.Web.DataContracts;
using Dot.Library.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IMessageRepository _repository;

        public MessageController(IMapper mapper,IMessageRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<MessageDto> GetAll()
        {
            var messageList = _repository.GetAll();
            var messages = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageDto>>(messageList);

            return messages;
        }

        [HttpGet("{id}", Name="GetMessage")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);

            var model = _mapper.Map<Message, MessageDto>(item);

            if(item==null)
            {
                return NotFound();
            }
            return new JsonResult(model);

           
        }

        [HttpPost]
        public IActionResult Create([FromBody] MessageDto item)
        {
            var model = _mapper.Map<MessageDto, Message>(item);

            if(model == null)
            {
                return BadRequest();
            }

            _repository.Insert(model);
            return CreatedAtRoute("GetMessage", new { id = item.Id }, item);
        }

        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody]MessageDto message)
        {
            var model = _mapper.Map<MessageDto, Message>(message);
            if(message == null || message.Id != id)
            {
                return BadRequest();
            }
            _repository.Update(model);
            return new NoContentResult();
        }

        [HttpDelete("id")]
        public IActionResult Delete(MessageDto message)
        {
            var model = _mapper.Map<MessageDto, Message>(message);
            _repository.Delete(model);
            return new NoContentResult();
        }
    }
}
