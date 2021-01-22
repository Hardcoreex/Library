using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    public class PatronsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatronsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patrons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patrons.ToListAsync());
        }

        // GET: Patrons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrons = await _context.Patrons
                .FirstOrDefaultAsync(m => m.PatronId == id);
            if (patrons == null)
            {
                return NotFound();
            }

            return View(patrons);
        }

        // GET: Patrons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patrons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatronId,PatronName")] Patrons patrons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patrons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patrons);
        }

        // GET: Patrons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrons = await _context.Patrons.FindAsync(id);
            if (patrons == null)
            {
                return NotFound();
            }
            return View(patrons);
        }

        // POST: Patrons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatronId,PatronName")] Patrons patrons)
        {
            if (id != patrons.PatronId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patrons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatronsExists(patrons.PatronId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patrons);
        }

        // GET: Patrons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrons = await _context.Patrons
                .FirstOrDefaultAsync(m => m.PatronId == id);
            if (patrons == null)
            {
                return NotFound();
            }

            return View(patrons);
        }

        // POST: Patrons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patrons = await _context.Patrons.FindAsync(id);
            _context.Patrons.Remove(patrons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatronsExists(int id)
        {
            return _context.Patrons.Any(e => e.PatronId == id);
        }
    }
}
