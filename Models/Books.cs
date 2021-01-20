using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Books
    {
        public int AuthorId { get; set; }

        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }

        public Books()
        {

        }
    }
}
