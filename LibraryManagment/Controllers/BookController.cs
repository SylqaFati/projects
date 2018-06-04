using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Data.Model;
using LibraryManagment.ViewModel;

namespace LibraryManagment.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository _bookrepository;
        private IAuthorRepository _authorRepository;

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookrepository = bookRepository;

            _authorRepository = authorRepository;

        }



        [Route("Book")]
        public IActionResult List(int? authorId, int? BorrowerId)
        {

            var bookrepos = _bookrepository.GetAllWithAutor();
            if(authorId == null && BorrowerId == null)
            {
                //show all books

                var books = _bookrepository.GetAllWithAutor();

               

                return CheckBooks(books);

            }
            else if( authorId != null)
            {

                var author = _authorRepository.GetWithBooks((int)authorId);
                if (author.Books.Count() == 0)
                {

                    return View("Empty");
                }
                else
                {

                    return View(author);
                }

                //filter by author id

            }
            else if (BorrowerId != null)
            {
                //filter by borrower id 

                var books = _bookrepository.FindWithAuthorAndBorrower(book => book.borrowerId == BorrowerId);

                return CheckBooks(books);
            }
            else
            {

                throw new Exception(); //throw expection 
            }

          
        }

        public IActionResult CheckBooks(IEnumerable<Book> books)
        {


            if (books.Count() == 0)
            {

                return View("Empty");
            }
            else
            {

                return View(books);
            }



        }


        public IActionResult Create()

        {
            var bookVM = new BookViewModel
            {
                Authors = _authorRepository.GetAll(),
               

            };

            return View(bookVM);


        }


        [HttpPost]
        public IActionResult Create(BookViewModel bookviewmodel)
        {
            if(!ModelState.IsValid)
            {
                bookviewmodel.Authors = _authorRepository.GetAll();
                return View(bookviewmodel);
            }

         

            _bookrepository.Create(bookviewmodel.Book);
            return RedirectToAction("List");

        }

        public IActionResult Update(int Id)
        {

             _bookrepository.GetById(Id);
            return View("Update");

        }

        [HttpPost]
        public IActionResult Update(BookViewModel bookvm)
        {

            if(!ModelState.IsValid)
            {

                bookvm.Authors = _authorRepository.GetAll();
                return View(bookvm);


            }

            _bookrepository.Update(bookvm.Book);
            return RedirectToAction("List");



        }

        public IActionResult Delete(int Id)
        {

            var bookdel = _bookrepository.GetById(Id);

            _bookrepository.Delete(bookdel);
            return RedirectToAction("List");
        }


    }
}