using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer.Model.Common
{
    public interface IBook
    {
        int BookID { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Genre { get; set; }
        int ReleaseYear { get; set; }

    }
}
