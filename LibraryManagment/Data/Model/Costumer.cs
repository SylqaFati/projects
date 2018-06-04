using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Model
{
    public class Costumer
    {
        public int CostumerId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string Name { get; set; }

    }
}
