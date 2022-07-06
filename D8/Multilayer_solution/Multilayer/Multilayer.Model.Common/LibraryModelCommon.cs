using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayer.Model.Common
{
    public interface ILibrary
    {
        int LibraryID { get; set; }
        string Address { get; set; }
        string City { get; set; }
    }
}
