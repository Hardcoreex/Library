using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Orders
    {
        public int PatronId { get; set; }

        public int BookId { get; set; }

        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
