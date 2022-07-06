using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer.Common
{
    public class Paging
    {
        public Paging()
        {
            rpp = 10;
            pageNumber = 1;
        }
        public Paging(int rpP, int pageNum)
        {
            rpp = rpP;
            pageNumber = pageNum;
        }
        public int rpp { get; set; }
        public int pageNumber { get; set; }
    }

    public class Sorting
    {
        public Sorting()
        {
            sortOrder = "ASC";
        }
        public Sorting(string orderby, string sortorder)
        {
            orderBy = orderby;
            sortOrder = sortorder;
        }
        public string orderBy { get; set; }
        public string sortOrder { get; set; }
    }

    public class LibraryFilter
    {
        public LibraryFilter(string searchstring, List<int> citiesid)
        {
            searchString = searchstring;
            citiesId = citiesid;
        }
        public string searchString { get; set; }
        public List<int> citiesId { get; set; }
    }

    public class BookFilter
    {

    }
}
