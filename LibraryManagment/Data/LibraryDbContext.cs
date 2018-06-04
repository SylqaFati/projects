using LibraryManagment.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data
{
    public class LibraryDbContext : DbContext
    {

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        public DbSet <Costumer> Costumers { get; set; }

        public DbSet<Book>Books { get; set; }

        public DbSet<Author> Authors { get; set; }



    }
}
