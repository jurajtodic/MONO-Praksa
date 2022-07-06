using Multilayer.Common;
using Multilayer.Model;
using Multilayer.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer.Repository
{
    public class LibraryRepository : ILibraryRepositoryCommon
    {
        string connectionString = "Data Source=ST-01;Initial Catalog=master;Integrated Security=True";

        public List<Library> GetLibraryData(Paging paging, Sorting sorting, LibraryFilter libraryFilter)
        {
            List<Library> libraryList = new List<Library>();

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                StringBuilder stringBuilder = new StringBuilder("SELECT LibraryID, Address, City FROM Library ", 500);
                // if - FILTERI
                if (libraryFilter != null)
                {
                    stringBuilder.Append("WHERE 1=1 ");
                    if(libraryFilter.searchString != null)
                    {
                        stringBuilder.AppendFormat("AND Address LIKE '{0}%' ", libraryFilter.searchString);
                    }
                    if(libraryFilter.citiesId != null)
                    {
                        // citiesId = SELECT LibraryID WHERE City IN('Osijek', 'Zagreb', 'Split', 'Dubrovnik')
                        //stringBuilder.AppendFormat("AND LibraryID IN ({0})", libraryFilter.citiesId);
                    }

                }

                stringBuilder.AppendFormat("ORDER BY {0} {1} ", sorting.orderBy, sorting.sortOrder);
                stringBuilder.Append("OFFSET @lowerLimit ROWS FETCH NEXT @rpp ROWS ONLY; ");                

                SqlCommand command = new SqlCommand(Convert.ToString(stringBuilder), connection);
                command.Parameters.AddWithValue("@lowerLimit", (paging.pageNumber - 1) * paging.rpp);
                command.Parameters.AddWithValue("@rpp", paging.rpp);

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
                    return null;
                }
                return libraryList;
            }
        }

        public Library GetLibraryDataById(int id)
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
                
                /*
                try
                {
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
                        return null;
                    }
                    return libraryList[0];
                }
                catch
                {
                    Console.WriteLine("Wrong command");
                }
                */

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        libraryList.Add(new Library(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                    }
                }
                else
                {
                    return null;
                }
                return libraryList[0];
            }
        }

        public Library PostLibraryData(Library library)
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
                return library;
            }
        }

        public Library PutLibraryData(int id, Library library)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                List<int> libraryListId = new List<int>();
                SqlCommand command2 = new SqlCommand("SELECT LibraryID FROM Library", connection);
                connection.Open();
                SqlDataReader reader = command2.ExecuteReader();

                // finding all ID's
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

                // putting
                if (!libraryListId.Exists(x => x == id))
                {
                    return null;
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
                    return library;
                }

            }
        }

        public bool DeleteLibraryData(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                
                List<int> libraryListId = new List<int>();
                SqlCommand command2 = new SqlCommand("SELECT LibraryID FROM Library", connection);
                connection.Open();
                SqlDataReader reader = command2.ExecuteReader();

                // finding all ID's
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

                // deleting
                if (!libraryListId.Exists(x => x == id))
                {
                    return false;
                }
                else
                {
                    SqlCommand command = new SqlCommand(
                        "DELETE FROM Library WHERE LibraryID=@id", connection);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }

            }
        }
    }
}
