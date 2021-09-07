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
    public class ReglersController : Controller
    {
        private readonly DbCon _context;

        public ReglersController(DbCon context)
        {
            _context = context;
        }

        // GET: Reglers
        public async Task<IActionResult> Index()
        {
            return View(await _context.regler.ToListAsync());
        }

        // GET: Reglers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regler = await _context.regler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regler == null)
            {
                return NotFound();
            }

            return View(regler);
        }

        // GET: Reglers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reglers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Regel,Pris")] Regler regler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regler);
        }

        // GET: Reglers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regler = await _context.regler.FindAsync(id);
            if (regler == null)
            {
                return NotFound();
            }
            return View(regler);
        }

        // POST: Reglers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Regel,Pris")] Regler regler)
        {
            if (id != regler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReglerExists(regler.Id))
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
            return View(regler);
        }

        // GET: Reglers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regler = await _context.regler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regler == null)
            {
                return NotFound();
            }

            return View(regler);
        }

        // POST: Reglers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regler = await _context.regler.FindAsync(id);
            _context.regler.Remove(regler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReglerExists(int id)
        {
            return _context.regler.Any(e => e.Id == id);
        }
    }
}
