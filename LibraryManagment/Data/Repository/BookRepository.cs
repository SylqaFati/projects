using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace LibraryManagment.Data.Repository
{


    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {

        }

        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(a => a.author)
                .Where(predicate);
        }

        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(a => a.author)
                .Include(b => b.borrower)
                .Where(predicate);
        }

        public IEnumerable<Book> GetAllWithAutor()
        {
            return _context.Books.Include(a => a.author);
        }
    }
}

       
    
