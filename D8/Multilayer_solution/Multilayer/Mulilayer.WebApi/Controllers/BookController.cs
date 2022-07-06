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

            List<BookRest> bookRestList = new List<BookRest>();

            foreach (Book book in result)
            {
                BookRest bookRest = new BookRest(book.BookID, book.Title, book.Author, book.Genre, book.ReleaseYear);
                bookRestList.Add(bookRest);
            }

            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No books found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, bookRestList);
            }

        }

        // GET: api/Book/5
        public HttpResponseMessage Get(int id)
        {
            BookService bookService = new BookService();

            Book result = bookService.GetBookDataByIdService(id);

            BookRest bookRest = new BookRest(result.BookID, result.Title, result.Author, result.Genre, result.ReleaseYear);

            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, bookRest);
            }
        }

        // POST: api/Book
        public HttpResponseMessage Post(Book book)
        {
            BookService bookService = new BookService();
            Book result = bookService.PostBookDataService(book);

            BookCreateRest bookCreateRest = new BookCreateRest(result.Title, result.Author, result.Genre, result.ReleaseYear);

            return Request.CreateResponse(HttpStatusCode.OK, bookCreateRest);
        }

        // PUT: api/Book/5
        public HttpResponseMessage Put(int id, Book book)
        {
            BookService bookService = new BookService();

            Book result = bookService.PutBookDataService(id, book);

            BookCreateRest bookCreateRest = new BookCreateRest(result.Title, result.Author, result.Genre, result.ReleaseYear);


            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, bookCreateRest);
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

        public class BookRest
        {
            public BookRest(int bookid, string title, string author, string genre, int year)
            {
                BookID = bookid;
                Title = title;
                Author = author;
                Genre = genre;
                ReleaseYear = year;
            }
            public int BookID { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public int ReleaseYear { get; set; }
        }

        public class BookCreateRest
        {
            public BookCreateRest(string title, string author, string genre, int year)
            {
                Title = title;
                Author = author;
                Genre = genre;
                ReleaseYear = year;
            }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public int ReleaseYear { get; set; }
        }
    }
}
