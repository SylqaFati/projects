using LibraryManagment.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.ViewModel
{
    public class BookViewModel
    {

        public IEnumerable<Author> Authors { get; set; }
        public Book Book { get; set; }
    }
}
