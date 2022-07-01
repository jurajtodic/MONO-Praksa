using Multilayer.Model;
using Multilayer.Repository;
using Multilayer.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer.Service
{
    public class BookService : IBookServiceCommon
    {
        public List<Book> GetBookDataService()
        {
            BookRepository bookRepo = new BookRepository();
            return bookRepo.GetBookData();
        }

        public List<Book> GetBookDataByIdService(int id)
        {
            BookRepository bookRepo = new BookRepository();
            return bookRepo.GetBookDataById(id);
        }

        public Book PostBookDataService(Book book)
        {
            BookRepository bookRepo = new BookRepository();
            return bookRepo.PostBookData(book);
        }

        public Book PutBookDataService(int id, Book book)
        {
            BookRepository bookRepo = new BookRepository();
            return bookRepo.PutBookData(id, book);
        }

        public bool DeleteBookDataService(int id)
        {
            BookRepository bookRepo = new BookRepository();
            return bookRepo.DeleteBookData(id);
        }

    }
}
