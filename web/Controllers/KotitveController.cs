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
    public class KotitveController : Controller
    {
        private readonly eShepherdContext _context;

        public KotitveController(eShepherdContext context)
        {
            _context = context;
        }

        // GET: Kotitve
        public async Task<IActionResult> Index(
                                    string sortOrder,
                                    string currentFilter,
                                    string searchString,
                                    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "ID_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Datum" ? "datum_asc" : "Datum";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString; 
            var kotitve = from k in _context.Kotitve
                 select k;
           if (!String.IsNullOrEmpty(searchString))
          {
               kotitve = kotitve.Where(s => s.Ovca.OvcaID.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ID_desc":
                    kotitve = kotitve.OrderByDescending(k => k.OvcaID);
                    break;
                case "Datum":
                    kotitve = kotitve.OrderBy(k => k.DatumKotitve);
                    break;
                 case "datum_asc":
                    kotitve = kotitve.OrderByDescending(k => k.DatumKotitve);
                    break;
                default:
                    kotitve = kotitve.OrderBy(k => k.DatumKotitve);
                    break;
            }
            int pageSize = 15;
            return View(await PaginatedList<Kotitev>.CreateAsync(kotitve.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Kotitve/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kotitev = await _context.Kotitve
                .Include(k => k.OvcaID)
                .Include(k => k.OvenID)
                .FirstOrDefaultAsync(m => m.KotitevID == id);
            if (kotitev == null)
            {
                return NotFound();
            }

            return View(kotitev);
        }

        // GET: Kotitve/Create
        public IActionResult Create()
        {
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID");
            ViewData["OvenID"] = new SelectList(_context.Ovni, "OvenID", "OvenID");
            return View();
        }

        // POST: Kotitve/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KotitevID,DatumKotitve,SteviloMladih,OvenID,OvcaID,SteviloMrtvih,Opombe")] Kotitev kotitev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kotitev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", kotitev.OvcaID);
            ViewData["OvenID"] = new SelectList(_context.Ovni, "OvenID", "OvenID", kotitev.OvenID);
            return View(kotitev);
        }

        // GET: Kotitve/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kotitev = await _context.Kotitve.FindAsync(id);
            if (kotitev == null)
            {
                return NotFound();
            }
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", kotitev.OvcaID);
            ViewData["OvenID"] = new SelectList(_context.Ovni, "OvenID", "OvenID", kotitev.OvenID);
            return View(kotitev);
        }

        // POST: Kotitve/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KotitevID,DatumKotitve,SteviloMladih,OvenID,OvcaID,SteviloMrtvih,Opombe")] Kotitev kotitev)
        {
            if (id != kotitev.KotitevID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kotitev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KotitevExists(kotitev.KotitevID))
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
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", kotitev.OvcaID);
            ViewData["OvenID"] = new SelectList(_context.Ovni, "OvenID", "OvenID", kotitev.OvenID);
            return View(kotitev);
        }

        // GET: Kotitve/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kotitev = await _context.Kotitve
                .Include(k => k.Ovca)
                .Include(k => k.Oven)
                .FirstOrDefaultAsync(m => m.KotitevID == id);
            if (kotitev == null)
            {
                return NotFound();
            }

            return View(kotitev);
        }

        // POST: Kotitve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kotitev = await _context.Kotitve.FindAsync(id);
            _context.Kotitve.Remove(kotitev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KotitevExists(int id)
        {
            return _context.Kotitve.Any(e => e.KotitevID == id);
        }
    }
}
