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
        public async Task<IActionResult> Index()
        {
            var eShepherdContext = _context.Kotitve.Include(k => k.Ovca).Include(k => k.Oven);
            return View(await eShepherdContext.ToListAsync());
        }

        // GET: Kotitve/Details/5
        public async Task<IActionResult> Details(int? id)
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
