using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagment.Controllers
{
    public class ReturnController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICostumerRepository _costumerRepository;

        public ReturnController(IBookRepository bookRepository, ICostumerRepository costumerRepository)
        {
            _bookRepository = bookRepository;
            _costumerRepository = costumerRepository;


        }
        // GET: /<controller>/
        public IActionResult List()
        {
            //load all the borrowed books
            var borrowedBooks = _bookRepository.FindWithAuthorAndBorrower(x => x.borrowerId != 0);
            //check the collection

            if (borrowedBooks == null || borrowedBooks.ToList().Count == 0) 
            {

                return View("Empty");
            }

            return View(borrowedBooks);
        }
     [HttpGet]
        public IActionResult ReturnABook(int Id)
        {
            //get the current book
            var book = _bookRepository.GetById(Id);

            //remove borrower
            book.borrower = null;
            book.borrowerId = 0;


            //update database
            _bookRepository.Update(book);

            //return to list method 
            return RedirectToAction("List");


        }
    }
}
