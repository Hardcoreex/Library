using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class OrdersDescription
    {
        public int Id { get; set; }
        public Orders Order { get; set; }
        public Patrons Patron { get; set; }
        public Books Book { get; set; }

        public OrdersDescription()
        {

        }
    }
}
