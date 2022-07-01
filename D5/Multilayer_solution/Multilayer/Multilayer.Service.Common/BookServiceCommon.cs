using Multilayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer.Service.Common
{
    public interface IBookServiceCommon
    {
        List<Book> GetBookDataService();
        List<Book> GetBookDataByIdService(int id);
        Book PostBookDataService(Book book);
        Book PutBookDataService(int id, Book book);
        bool DeleteBookDataService(int id);
    }
}
