using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class JagenjckiController : Controller
    {
        private readonly eShepherdContext _context;

        public JagenjckiController(eShepherdContext context)
        {
            _context = context;
        }

        // GET: Jagenjcki
        public async Task<IActionResult> Index(string sortOrder)
        {
                ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "ID_desc" : "";
                ViewData["KotitevIDSortParm"] = sortOrder == "KotitevID" ? "kotitevid_desc" : "KotitevID";
                var jagenjcki = from j in _context.Jagenjcki
                                select j;
                switch (sortOrder)
                {
                    case "ID_desc":
                        jagenjcki = jagenjcki.OrderByDescending(j => j.IdJagenjcka);
                        break;
                    case "kotitevid_desc":
                        jagenjcki = jagenjcki.OrderBy(j => j.KotitevID);
                        break;
                    case "KotitevID":
                        jagenjcki = jagenjcki.OrderBy(j => j.KotitevID);
                        break;
                    default:
                        jagenjcki = jagenjcki.OrderBy(j => j.IdJagenjcka);
                        break;
                }
                return View(await jagenjcki.AsNoTracking().ToListAsync());
            }

        // GET: Jagenjcki/Details/5
        public async Task<IActionResult> Details(String? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jagenjcek = await _context.Jagenjcki
                .Include(j => j.skritIdJagenjcka)
                .Include(j => j.IdJagenjcka)
                .Include(j => j.kotitev)
                .Include(j => j.spol)
                .FirstOrDefaultAsync(m => m.IdJagenjcka == id);

            if (jagenjcek == null)
            {
                return NotFound();
            }

            return View(jagenjcek);
        }

        // GET: Jagenjcki/Create
        public IActionResult Create()
        {
            ViewData["KotitevID"] = new SelectList(_context.Kotitve, "KotitevID", "KotitevID");
            return View();
        }

        // POST: Jagenjcki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("skritIdJagenjcka,IdJagenjcka,KotitevID,spol")] Jagenjcek jagenjcek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jagenjcek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KotitevID"] = new SelectList(_context.Kotitve, "KotitevID", "KotitevID", jagenjcek.KotitevID);
            return View(jagenjcek);
        }

        // GET: Jagenjcki/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jagenjcek = await _context.Jagenjcki.FindAsync(id);
            if (jagenjcek == null)
            {
                return NotFound();
            }
            ViewData["KotitevID"] = new SelectList(_context.Kotitve, "KotitevID", "KotitevID", jagenjcek.KotitevID);
            return View(jagenjcek);
        }

        // POST: Jagenjcki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("skritIdJagenjcka,IdJagenjcka,KotitevID,spol")] Jagenjcek jagenjcek)
        {
            if (id != jagenjcek.skritIdJagenjcka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jagenjcek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JagenjcekExists(jagenjcek.skritIdJagenjcka))
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
            ViewData["KotitevID"] = new SelectList(_context.Kotitve, "KotitevID", "KotitevID", jagenjcek.KotitevID);
            return View(jagenjcek);
        }

        // GET: Jagenjcki/Delete/5
        public async Task<IActionResult> Delete(String id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jagenjcek = await _context.Jagenjcki
                .Include(j => j.IdJagenjcka)
                .Include(j => j.skritIdJagenjcka)
                .Include(j => j.kotitev)
                .Include(j => j.spol)
                .FirstOrDefaultAsync(m => m.IdJagenjcka == id);
            if (jagenjcek == null)
            {
                return NotFound();
            }

            return View(jagenjcek);
        }

        // POST: Jagenjcki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jagenjcek = await _context.Jagenjcki.FindAsync(id);
            _context.Jagenjcki.Remove(jagenjcek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JagenjcekExists(int id)
        {
            return _context.Jagenjcki.Any(e => e.skritIdJagenjcka == id);
        }
    }
}
