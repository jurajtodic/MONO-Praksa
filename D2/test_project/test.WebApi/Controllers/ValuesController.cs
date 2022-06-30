using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace test.WebApi.Controllers
{

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }

    public static class PeopleList
    {
        public static List<Person> _list;

        public static object Request { get; private set; }

        static PeopleList()
        {
            _list = new List<Person>();
        }

        public static void FindAndUpdate(int id, Person person)
        {
            foreach(Person per in _list)
            {
                if(per.Id == id)
                {
                    per.Id = person.Id;
                    per.Name = person.Name;
                    per.Age = person.Age;
                }
            }
        }

        public static void FindAndDelete(int id)
        {
            foreach(Person per in _list.ToList())
            {
                if (per.Id == id)
                {
                    _list.Remove(per);
                    return;
                }
            }
        
        }        
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            if (PeopleList._list == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Person not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, PeopleList._list);
            }
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            if (PeopleList._list.Exists(x => x.Id == id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, PeopleList._list.Find(x => x.Id == id));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Person not found");
            }
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] Person person)
        {
            if (PeopleList._list.Exists(x => x.Id == person.Id))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "ID has to be unique");
            }
            else
            {
                PeopleList._list.Add(person);
                return Request.CreateResponse(HttpStatusCode.Created, PeopleList._list);
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] Person person)
        {
            if (PeopleList._list.Exists(x => x.Id == id))
            {
                PeopleList.FindAndUpdate(id, person);
                return Request.CreateResponse(HttpStatusCode.OK, PeopleList._list);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "ID not found");
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            if (PeopleList._list.Exists(x => x.Id == id))
            {
                PeopleList.FindAndDelete(id);
                return Request.CreateResponse(HttpStatusCode.OK, PeopleList._list);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "ID not found");
            }
        }
    }
}
