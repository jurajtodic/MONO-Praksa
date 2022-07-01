using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multilayer.Model.Common;

namespace Multilayer.Model
{
    public class Book : IBook
    {
        public Book(int bookid, string title, string author, string genre, int year)
        {
            BookID = bookid;
            Title = title;
            Author = author;
            Genre = genre;
            ReleaseYear = year;
        }

        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }

    }
}
