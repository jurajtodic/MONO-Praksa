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
        public HttpResponseMessage Get()
        {
            LibraryService libService = new LibraryService();

            List<Library> result = libService.GetLibraryDataService();

            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No Libraries found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            
        }

        // GET: api/Library/5
        public HttpResponseMessage Get(int id)
        {
            LibraryService libService = new LibraryService();

            List<Library> result = libService.GetLibraryDataByIdService(id);

            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }

        // POST: api/Library
        public HttpResponseMessage Post(Library library)
        {
            LibraryService libService = new LibraryService();
            Library result = libService.PostLibraryDataService(library);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/Library/5
        public HttpResponseMessage Put(int id, Library library)
        {
            LibraryService libService = new LibraryService();

            Library result = libService.PutLibraryDataService(id, library);

            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
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
        
    }
 
}
