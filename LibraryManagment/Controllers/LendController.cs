using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Data.Interfaces;
using LibraryManagment.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagment.Controllers
{
    public class LendController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICostumerRepository _costumerRepository;

        public LendController(IBookRepository bookRepository, ICostumerRepository costumerRepository)
        {

            _bookRepository = bookRepository;
            _costumerRepository = costumerRepository;


        }

        public IActionResult List()
        {

            var availableBooks = _bookRepository.FindWithAuthor(m => m.borrowerId == 0);

            if(availableBooks.Count()==0)
            {

                return View ("Empty");
            }
            else
            {
                return View (availableBooks);

            }

        }

        public IActionResult LendBook(int bookId)
        {
            var LendBookVM = new LendViewModel
            {
                book = _bookRepository.GetById(bookId),
                Costumers = _costumerRepository.GetAll()
                


        };
            return View(LendBookVM);






        }
        [HttpPost]
        public IActionResult LendBook(LendViewModel lendViewModel)
        {

            var book = _bookRepository.GetById(lendViewModel.book.BookId );
            var costumers = _costumerRepository.GetById(lendViewModel.book.borrowerId);

            book.borrower = costumers;
            _bookRepository.Update(book);
            return RedirectToAction("List");


        }





    }
}
