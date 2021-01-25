using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Authors
    {
        [Key]
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

    }
}
