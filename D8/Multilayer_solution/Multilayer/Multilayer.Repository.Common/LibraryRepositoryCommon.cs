using Multilayer.Common;
using Multilayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer.Repository.Common
{
    public interface ILibraryRepositoryCommon
    {
        List<Library> GetLibraryData(Paging paging, Sorting sorting, LibraryFilter libraryFilter);
        Library GetLibraryDataById(int id);
        Library PostLibraryData(Library library);
        Library PutLibraryData(int id, Library library);
        bool DeleteLibraryData(int id);

    }
}
