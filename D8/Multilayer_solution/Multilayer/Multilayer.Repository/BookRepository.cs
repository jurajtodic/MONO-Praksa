using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multilayer.Model.Common;
using Multilayer.Model;
using System.Data.SqlClient;
using Multilayer.Repository.Common;

namespace Multilayer.Repository
{
    public class BookRepository : IBookRepositoryCommon
    {
        string connectionString = "Data Source=ST-01;Initial Catalog=master;Integrated Security=True";

        public List<Book> GetBookData()
        {
            List<Book> bookList = new List<Book>();

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT BookID, Title, Author, Genre, ReleaseYear FROM Book;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bookList.Add(new Book(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                    }
                }
                else
                {
                    return null;
                }
                return bookList;
            }
        }

        public Book GetBookDataById(int id)
        {
            List<Book> bookList = new List<Book>();

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                "SELECT BookID, Title, Author, Genre, ReleaseYear FROM Book WHERE BookID=@id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bookList.Add(new Book(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
                    }
                }
                else
                {
                    return null;
                }
                return bookList[0];
            }
        }

        public Book PostBookData(Book book)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                "INSERT INTO Book (BookID, Title, Author, Genre, ReleaseYear) VALUES (@BookID, @Title, @Author, @Genre, @ReleaseYear)", connection);
                connection.Open();

                command.Parameters.AddWithValue("@BookID", book.BookID);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@ReleaseYear", book.ReleaseYear);

                command.ExecuteNonQuery();
                return book;
            }
        }


        public Book PutBookData(int id, Book book)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                // finding all ID's
                List<int> bookListId = new List<int>();
                SqlCommand command2 = new SqlCommand("SELECT BookID FROM Book", connection);
                connection.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bookListId.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }

                if (!bookListId.Exists(x => x == id))
                {
                    return null;
                }
                else
                {
                    SqlCommand command = new SqlCommand(
                        "UPDATE Book SET Title = @title, Author = @author, Genre = @genre, ReleaseYear = @releaseYear WHERE BookID = @bookId", connection);
                    command.Parameters.AddWithValue("@title", book.Title);
                    command.Parameters.AddWithValue("@author", book.Author);
                    command.Parameters.AddWithValue("@genre", book.Genre);
                    command.Parameters.AddWithValue("@releaseYear", book.ReleaseYear);
                    command.Parameters.AddWithValue("@bookID", book.BookID);

                    command.ExecuteNonQuery();
                    connection.Close();
                    return book;
                }
            }
        }

        public bool DeleteBookData(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                // finding all ID's
                List<int> bookListId = new List<int>();
                SqlCommand command2 = new SqlCommand("SELECT BookID FROM Book", connection);
                connection.Open();
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bookListId.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }

                if (!bookListId.Exists(x => x == id))
                {
                    return false;
                }
                else
                {
                    SqlCommand command = new SqlCommand(
                        "DELETE FROM Book WHERE BookID=@id", connection);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }

            }
        }
    } 
}
