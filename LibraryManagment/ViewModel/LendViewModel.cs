﻿using LibraryManagment.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.ViewModel
{
    public class LendViewModel
    {
        public Book book { get; set; }
        public IEnumerable<Costumer> Costumers { get; set; }

    }
}
