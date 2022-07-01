using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;

namespace test.WebApi.Controllers
{
    public class Library
    {
        public Library(int libId, string addy, string city)
        {
            LibraryID = libId;
            Address = addy;
            City = city;
        }

        public int LibraryID;
        public string Address;
        public string City;
    }

    

    public class LibraryController : ApiController
    {
        string connectionString = "Data Source=ST-01;Initial Catalog=master;Integrated Security=True";

        // GET: api/Library
        public HttpResponseMessage Get()
        {
            List<Library> libraryList = new List<Library>();

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT LibraryID, Address, City FROM Library;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        libraryList.Add(new Library(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, libraryList);
            }
        }

        // GET: api/Library/5
        public HttpResponseMessage Get(int id)
        {
            List<Library> libraryList = new List<Library>();

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                "SELECT LibraryID, Address, City FROM Library WHERE LibraryID=@id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        libraryList.Add(new Library(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, libraryList);
            }
        }

        // POST: api/Library
        public HttpResponseMessage Post([FromBody] Library library)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                "INSERT INTO Library (LibraryID, Address, City) VALUES (@LibraryID, @Address, @City)", connection);
                connection.Open();

                command.Parameters.AddWithValue("@LibraryID", library.LibraryID);
                command.Parameters.AddWithValue("@Address", library.Address);
                command.Parameters.AddWithValue("@City", library.City);

                command.ExecuteNonQuery();
                return Request.CreateResponse(HttpStatusCode.OK, "Done");
            }
        }

        // PUT: api/Library/5
        public HttpResponseMessage Put(int id, [FromBody]Library library)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                // finding all ID's
                List<int> libraryListId = new List<int>();
                SqlCommand command2 = new SqlCommand("SELECT LibraryID FROM Library", connection);
                connection.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        libraryListId.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }

                if (!libraryListId.Exists(x => x == id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Id not found");
                }
                else
                {
                    SqlCommand command = new SqlCommand(
                        "UPDATE Library SET Address = @libAddress, City = @libCity WHERE LibraryID = @libId", connection);
                    command.Parameters.AddWithValue("@libAddress", library.Address);
                    command.Parameters.AddWithValue("@libCity", library.City);
                    command.Parameters.AddWithValue("@libId", id);

                    command.ExecuteNonQuery();
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, "Done");
                }

            }
        }

        // DELETE: api/Library/5
        public HttpResponseMessage Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                // finding all ID's
                List<int> libraryListId = new List<int>();
                SqlCommand command2 = new SqlCommand("SELECT LibraryID FROM Library", connection);
                connection.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        libraryListId.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }

                if (!libraryListId.Exists(x => x == id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Id not found");
                }
                else
                {
                    SqlCommand command = new SqlCommand(
                        "DELETE FROM Library WHERE LibraryID=@id", connection);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, "Done");
                }

            }
        }
    }
}
