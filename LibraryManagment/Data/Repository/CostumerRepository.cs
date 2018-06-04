using LibraryManagment.Data.Interfaces;
using LibraryManagment.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Repository
{
    public class CostumerRepository:Repository<Costumer>, ICostumerRepository
    {
        public CostumerRepository(LibraryDbContext context): base(context)
        {

        }
    }
}
