using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagment.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository  _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }


       [Route("Author")]
        public IActionResult List()
        {
            var authors = _authorRepository.GetAllWithBooks();

             if (authors.Count() == 0)
             { 
                return View("Empty");
              }


                return View(authors);
        }



        public IActionResult Create()
        {

            return View("Create");
        }


        [HttpPost]

        public  IActionResult Create (Author author)
        {
            if (!ModelState.IsValid)
            {

                return View("List");

            }


            _authorRepository.Create(author);

            return RedirectToAction("List");


              
        }

        public IActionResult Update(int Id)
        {

            var author = _authorRepository.GetById(Id);

            if (author == null) return NotFound();



            return View(author);

        }
        [HttpPost]
        public IActionResult Update(Author author)
        {

            if (!ModelState.IsValid)
            {

                return View("List");

            }
          _authorRepository.Update(author);
            return RedirectToAction("List");

        }

        public IActionResult Delete( int Id)
        {

            var authorDel = _authorRepository.GetById(Id);
            if (!ModelState.IsValid)
            {

                return View("List");

            }

           
            _authorRepository.Delete(authorDel);
            return RedirectToAction("List");



        }





       
    }
}
