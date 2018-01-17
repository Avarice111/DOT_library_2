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
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;

        public OrderController(IMapper mapper,IOrderRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }
        
        [HttpGet("id", Name="GetOrder")]
        public IActionResult getOrderById(long id)
        {
            var item = _repository.Get(id);
           // var model = _mapper.Map<Order, OrderDto>(item);
            if(item==null)
            {
                return NotFound();
            }
            
            return Json(
                new OrderDto()
                {
                    OrderId = item.OrderId,
                    Books = (List<BookSummaryDto>) item.Books.Select(book => new BookSummaryDto(){Id = book.BookId,ImgUrl = book.Cover,Isbn = 1,Title = book.Title}),
                    Date = item.Date,
                    userId = item.User.ID
                }
                );           
        }
         
    }
}
