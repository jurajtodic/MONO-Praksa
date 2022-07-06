using Multilayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer.Repository.Common
{
    public interface IBookRepositoryCommon
    {
        List<Book> GetBookData();
        Book GetBookDataById(int id);
        Book PostBookData(Book book);
        Book PutBookData(int id, Book book);
        bool DeleteBookData(int id);
    }
}
