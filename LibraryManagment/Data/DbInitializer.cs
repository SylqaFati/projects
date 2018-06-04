using LibraryManagment.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data
{
    public class DbInitializer
    {

        public static void Seed(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();

                var fati = new Costumer { Name = "Fatih" };
                var fatlum = new Costumer { Name = "Lumi" };
                var besnik = new Costumer { Name = "Beni" };


                context.Costumers.Add(fati);
                context.Costumers.Add(fatlum);
                context.Costumers.Add(besnik);


                var Tolstoy = new Author
                {
                    name = "Leo Tolstoy",
                    Books = new List<Book>()
                    {
                        new Book {title ="ana karenina"},
                        new Book { title = "war and peace" },
                        new Book { title = "Hajdi Murad" }



                    }

                };


                var Dostoyevsky = new Author
                {
                    name = "Fyodor Dostoyevski",
                    Books = new List<Book>()
                    {
                        new Book {title ="crime and punishment"},
                        new Book { title = "The Idiot" },
                        new Book { title = "Karamazov Brothers" }



                    }

                };

                var Pushkin = new Author
                {
                    name = "Alexander Pushkin",
                    Books = new List<Book>()
                    {
                        new Book {title ="crime "},
                        new Book { title = "The stupid" },
                       



                    }

                };


                context.Authors.Add(Tolstoy);
                context.Authors.Add(Dostoyevsky);
                context.Authors.Add(Pushkin);


                context.SaveChanges();

            }


        }

    }
}
