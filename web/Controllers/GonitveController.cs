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
    public class GonitveController : Controller
    {
        private readonly eShepherdContext _context;

        public GonitveController(eShepherdContext context)
        {
            _context = context;
        }

        // GET: Gonitve
        public async Task<IActionResult> Index()
        {
            var eShepherdContext = _context.Gonitve.Include(g => g.Ovca).Include(g => g.Oven);
            return View(await eShepherdContext.ToListAsync());
        }

        // GET: Gonitve/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gonitev = await _context.Gonitve
                .Include(g => g.Ovca)
                .Include(g => g.Oven)
                .FirstOrDefaultAsync(m => m.GonitevID == id);
            if (gonitev == null)
            {
                return NotFound();
            }

            return View(gonitev);
        }

        // GET: Gonitve/Create
        public IActionResult Create()
        {
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID");
            ViewData["OvenID"] = new SelectList(_context.Ovni, "OvenID", "OvenID");
            return View();
        }

        // POST: Gonitve/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GonitevID,DatumGonitve,OvcaID,OvenID,PredvidenaKotitev,Opombe")] Gonitev gonitev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gonitev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", gonitev.OvcaID);
            ViewData["OvenID"] = new SelectList(_context.Ovni, "OvenID", "OvenID", gonitev.OvenID);
            return View(gonitev);
        }

        // GET: Gonitve/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gonitev = await _context.Gonitve.FindAsync(id);
            if (gonitev == null)
            {
                return NotFound();
            }
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", gonitev.OvcaID);
            ViewData["OvenID"] = new SelectList(_context.Ovni, "OvenID", "OvenID", gonitev.OvenID);
            return View(gonitev);
        }

        // POST: Gonitve/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GonitevID,DatumGonitve,OvcaID,OvenID,PredvidenaKotitev,Opombe")] Gonitev gonitev)
        {
            if (id != gonitev.GonitevID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gonitev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GonitevExists(gonitev.GonitevID))
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
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", gonitev.OvcaID);
            ViewData["OvenID"] = new SelectList(_context.Ovni, "OvenID", "OvenID", gonitev.OvenID);
            return View(gonitev);
        }

        // GET: Gonitve/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gonitev = await _context.Gonitve
                .Include(g => g.Ovca)
                .Include(g => g.Oven)
                .FirstOrDefaultAsync(m => m.GonitevID == id);
            if (gonitev == null)
            {
                return NotFound();
            }

            return View(gonitev);
        }

        // POST: Gonitve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gonitev = await _context.Gonitve.FindAsync(id);
            _context.Gonitve.Remove(gonitev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GonitevExists(int id)
        {
            return _context.Gonitve.Any(e => e.GonitevID == id);
        }
    }
}
