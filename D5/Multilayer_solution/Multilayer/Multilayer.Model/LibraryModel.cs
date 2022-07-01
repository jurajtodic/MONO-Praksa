using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multilayer.Model.Common;

namespace Multilayer.Model
{
    public class Library : ILibraryModelCommon
    {
        public Library(int libId, string addy, string city)
        {
            LibraryID = libId;
            Address = addy;
            City = city;
        }

        public int LibraryID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
