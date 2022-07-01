using Multilayer.Model;
using Multilayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mulilayer.WebApi.Controllers
{
    public class BookController : ApiController
    {
        // GET: api/Book
        public HttpResponseMessage Get()
        {
            BookService bookService = new BookService();

            List<Book> result = bookService.GetBookDataService();

            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No books found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }

        }

        // GET: api/Book/5
        public HttpResponseMessage Get(int id)
        {
            BookService bookService = new BookService();

            List<Book> result = bookService.GetBookDataByIdService(id);

            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }

        // POST: api/Book
        public HttpResponseMessage Post(Book book)
        {
            BookService bookService = new BookService();
            Book result = bookService.PostBookDataService(book);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/Book/5
        public HttpResponseMessage Put(int id, Book book)
        {
            BookService bookService = new BookService();

            Book result = bookService.PutBookDataService(id, book);

            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }

        // DELETE: api/Book/5
        public HttpResponseMessage Delete(int id)
        {
            BookService bookService = new BookService();

            bool result = bookService.DeleteBookDataService(id);

            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }
    }
}
