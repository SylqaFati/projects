using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Models;
using LibraryManagment.Data.Interfaces;
using LibraryManagment.ViewModel;

namespace LibraryManagment.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICostumerRepository _costumerRepository;
        private readonly IAuthorRepository _authorRepository;

        public HomeController(IBookRepository bookRepository, ICostumerRepository costumerRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _costumerRepository = costumerRepository;
            _authorRepository = authorRepository;

        }
        public IActionResult Index()
        {

            var HomeVm = new HomeViewModel()
            {
                AuthorCount = _authorRepository.Count(x => true),
                BookCount = _bookRepository.Count(x => true),
                CostumerCount = _costumerRepository.Count(x => true),
                LendBookCount = _bookRepository.Count(x => x.borrower != null)


            };
            return View(HomeVm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
