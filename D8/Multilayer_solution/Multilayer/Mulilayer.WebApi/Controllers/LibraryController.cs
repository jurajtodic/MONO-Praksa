using Multilayer.Common;
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
    public class LibraryController : ApiController
    {
        // GET: api/Library        
        // parametar za date picked
        // parametar za lowerBound - higherBound
        public HttpResponseMessage Get(int rpp, int pageNumber, string orderBy, string sortOrder, string searchString, [FromUri]List<int> citiesId)    
        {
            LibraryService libService = new LibraryService();

            Paging paging = new Paging(rpp, pageNumber);
            Sorting sorting = new Sorting(orderBy, sortOrder);
            LibraryFilter libraryFilter = new LibraryFilter(searchString, citiesId);

            List<Library> result = libService.GetLibraryDataService(paging, sorting, libraryFilter);
            List<LibraryRest> libRestList = new List<LibraryRest>();

            foreach (Library lib in result)
            {
                LibraryRest libRest = new LibraryRest(lib.LibraryID, lib.Address, lib.City);
                libRestList.Add(libRest);
            }
            
            if (libRestList == null)    // result == null
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No Libraries found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, libRestList);
            }
            
        }

        // GET: api/Library/5
        public HttpResponseMessage Get(int id)
        {
            LibraryService libService = new LibraryService();

            Library result = libService.GetLibraryDataByIdService(id);
            LibraryRest libRest = new LibraryRest(result.LibraryID, result.Address, result.City);
            

            if (libRest == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, libRest);
            }
        }

        // POST: api/Library
        public HttpResponseMessage Post(Library library)
        {
            LibraryService libService = new LibraryService();
            Library result = libService.PostLibraryDataService(library);

            LibraryCreateRest libCreate = new LibraryCreateRest(result.Address, result.City);

            return Request.CreateResponse(HttpStatusCode.OK, libCreate);
        }

        // PUT: api/Library/5
        public HttpResponseMessage Put(int id, Library library)
        {
            LibraryService libService = new LibraryService();

            Library result = libService.PutLibraryDataService(id, library);
            LibraryCreateRest libraryCreateRest = new LibraryCreateRest(result.Address, result.City);

            if (libraryCreateRest == null)  
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, libraryCreateRest);
            }
        }

        // DELETE: api/Library/5
        public HttpResponseMessage Delete(int id)
        {
            LibraryService libService = new LibraryService();

            bool result = libService.DeleteLibraryDataService(id);

            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }

        public class LibraryRest
        {
            public LibraryRest(int libId, string addy, string city)
            {
                LibraryID = libId;
                Address = addy;
                City = city;
            }

            public int LibraryID { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
        }

        public class LibraryCreateRest
        {
            public LibraryCreateRest(string addy, string city)
            {
                Address = addy;
                City = city;
            }

            public string Address { get; set; }
            public string City { get; set; }
        }
    }
 
}
