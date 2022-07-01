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
    public class LibraryService : ILibraryServiceCommon
    {
        public List<Library> GetLibraryDataService()
        {
            LibraryRepository libRepo = new LibraryRepository();
            return libRepo.GetLibraryData();
        }

        public List<Library> GetLibraryDataByIdService(int id)
        {
            LibraryRepository libRepo = new LibraryRepository();
            return libRepo.GetLibraryDataById(id);
        }

        public Library PostLibraryDataService(Library library)
        {
            LibraryRepository libRepo = new LibraryRepository();
            return libRepo.PostLibraryData(library);
        }

        public Library PutLibraryDataService(int id, Library library)
        {
            LibraryRepository libRepo = new LibraryRepository();
            return libRepo.PutLibraryData(id, library);
        }

        public bool DeleteLibraryDataService(int id)
        {
            LibraryRepository libRepo = new LibraryRepository();
            return libRepo.DeleteLibraryData(id);
        }


    }
}
