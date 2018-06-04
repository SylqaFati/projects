using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using LibraryManagment.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Controllers
{
    public class CostumerController : Controller
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly IBookRepository _bookRepository;

        public CostumerController(ICostumerRepository costumerRepository, IBookRepository bookRepository)
        {

            _costumerRepository = costumerRepository;
            _bookRepository = bookRepository;

        }
        [Route("Costumer/list")]
        public IActionResult List()
        {
            var costumerVM = new List<CostumerViewModel>();

            var costumers = _costumerRepository.GetAll();

            if (costumers.Count() == 0)
            {

                return View("Empty");
            }

         

            foreach (var costumeri in costumers)
            {
                costumerVM.Add(new CostumerViewModel
                {
                    costumer = costumeri,
                    BookCount = _bookRepository.Count(x => x.borrowerId == costumeri.CostumerId)
                    
     

                });
               

            }
            return View(costumerVM);

        }


        public IActionResult Create()
        {

            return View("Create");

        }
        [HttpPost]
        public IActionResult Create(Costumer costumer)
        {

            if(!ModelState.IsValid)
            {

                return View("List");
            }

            _costumerRepository.Create(costumer);
            return RedirectToAction("List");



        }

     
        public IActionResult Delete ( int  Id)
        {
            var costum =  _costumerRepository.GetById(Id);

            _costumerRepository.Delete(costum);
            
             

            return RedirectToAction("List");

        }

        public IActionResult Update(int Id)
        {
           var customeri =  _costumerRepository.GetById(Id);
            return View(customeri);


        }



        [HttpPost]
        public  IActionResult Update(Costumer costumer)
        {
            

            if (!ModelState.IsValid)
            {

                return  View("List");
            }

            _costumerRepository.Update(costumer);
           return RedirectToAction("List");

        }


    }
}
