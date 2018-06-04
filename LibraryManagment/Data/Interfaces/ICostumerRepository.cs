using LibraryManagment.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Interfaces
{
     public interface ICostumerRepository :IRepository<Costumer>
    {
        //IEnumerable<Costumer> GetAllCostumers();
        //Costumer GetCostumer(int id);

    }
}
