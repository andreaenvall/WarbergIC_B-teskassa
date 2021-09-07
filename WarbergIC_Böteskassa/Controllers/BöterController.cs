using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WarbergIC_Böteskassa.Data;
using WarbergIC_Böteskassa.Models;

namespace WarbergIC_Böteskassa.Controllers
{
    public class BöterController : Controller
    {
        private readonly DbCon _context;

        public BöterController(DbCon context)
        {
            _context = context;
        }

        // GET: Böter
        public async Task<IActionResult> Index()
        {
            return View(await _context.böter.ToListAsync());
        }

        // GET: Böter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var böter = await _context.böter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (böter == null)
            {
                return NotFound();
            }

            return View(böter);
        }

        // GET: Böter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Böter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,Kommentar,Åtalad,Åtalspunkt")] Böter böter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(böter);
                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["Åtalad"] = new SelectList(_context.person, "Id", "FullName", böter.Åtalad);
            ViewData["Åtalspunkt"] = new SelectList(_context.regler, "Id", "Regel", böter.Åtalspunkt);
            return View(böter);
        }

        // GET: Böter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var böter = await _context.böter.FindAsync(id);
            if (böter == null)
            {
                return NotFound();
            }
          
            return View(böter);
        }

        // POST: Böter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,Kommentar,Åtalad,Åtalspunkt")] Böter böter)
        {
            if (id != böter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(böter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BöterExists(böter.Id))
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
            ViewData["Åtalad"] = new SelectList(_context.person, "Id", "FullName", böter.Åtalad);
            ViewData["Åtalspunkt"] = new SelectList(_context.regler, "Id", "Regel", böter.Åtalspunkt);
            return View(böter);
        }

        // GET: Böter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var böter = await _context.böter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (böter == null)
            {
                return NotFound();
            }

            return View(böter);
        }

        // POST: Böter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var böter = await _context.böter.FindAsync(id);
            _context.böter.Remove(böter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BöterExists(int id)
        {
            return _context.böter.Any(e => e.Id == id);
        }
    }
}
