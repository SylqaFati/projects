using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Data.Model
{
    public class Book
    {
        public int BookId { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string title { get; set; }

        public Author author { get; set; }
        public int AuthorId { get; set; }
        [Required]
        public virtual Costumer borrower { get; set; }
        public int borrowerId { get; set; }
    }
}
