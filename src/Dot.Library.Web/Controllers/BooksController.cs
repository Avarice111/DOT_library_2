using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Library.Web.DataContracts;
using Dot.Library.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Library.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Books")]
    public class BooksController : Controller
    {

        LibraryContext _libraryContext;

        public BooksController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IActionResult GetListOfBooks()
        {
            var books = _libraryContext.Books.ToList();
            return Json(books.Select(book => new BookSummaryDto
            {
                Id = book.BookId,
                ImgUrl = book.Cover,
                Isbn = 1,
                Title = book.Title
            }));
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult AddBook([FromBody]BookSummaryDto book)
        {
            _libraryContext.Books.Add(new Database.Book
            {
                Availability=true,
                Title = book.Title,
                Cover = book.ImgUrl
            });
            _libraryContext.SaveChanges();
            return NoContent();
        }

    }
}