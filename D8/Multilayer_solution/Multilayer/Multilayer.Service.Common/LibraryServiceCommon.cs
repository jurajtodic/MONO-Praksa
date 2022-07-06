using Multilayer.Common;
using Multilayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer.Service.Common
{
    public interface ILibraryServiceCommon
    {
        List<Library> GetLibraryDataService(Paging paging, Sorting sorting, LibraryFilter libraryFilter);
        Library GetLibraryDataByIdService(int id);
        Library PostLibraryDataService(Library library);
        Library PutLibraryDataService(int id, Library library);
        bool DeleteLibraryDataService(int id);
    }
}
