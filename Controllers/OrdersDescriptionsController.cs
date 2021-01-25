using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Authorization;

namespace Library.Controllers
{
    public class OrdersDescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersDescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdersDescriptions
        [Authorize]
        public IActionResult Index()
        {
            var alist = from s in _context.Orders
                join sa in _context.Patrons on s.PatronId equals sa.PatronId
                join saa in _context.Books on s.BookId equals saa.BookId

                select new OrdersDescription
                {
                    Id = s.OrderId,
                    Order = s,
                    Patron = sa,
                    Book = saa,

                };

            return View(alist.ToList());

        }

        // GET: OrdersDescriptions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alist = from s in _context.Orders
                join sa in _context.Patrons on s.PatronId equals sa.PatronId
                join saa in _context.Books on s.BookId equals saa.BookId

                select new OrdersDescription
                {

                    Order = s,
                    Patron = sa,
                    Book = saa,

                };


            return View(alist.FirstOrDefault());
        }
    }
}

        