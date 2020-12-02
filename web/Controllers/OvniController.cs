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
    public class OvniController : Controller
    {
        private readonly eShepherdContext _context;

        public OvniController(eShepherdContext context)
        {
            _context = context;
        }

        // GET: Ovni
        public async Task<IActionResult> Index()
        {
            var eShepherdContext = _context.Ovni.Include(o => o.Ovca).Include(o => o.creda);
            return View(await eShepherdContext.ToListAsync());
        }

        // GET: Ovni/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oven = await _context.Ovni
                .Include(o => o.Ovca)
                .Include(o => o.creda)
                .FirstOrDefaultAsync(m => m.OvenID == id);
            if (oven == null)
            {
                return NotFound();
            }

            return View(oven);
        }

        // GET: Ovni/Create
        public IActionResult Create()
        {
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID");
            ViewData["CredaID"] = new SelectList(_context.Crede, "CredeID", "CredeID");
            return View();
        }

        // POST: Ovni/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OvenID,CredaID,DatumRojstva,Pasma,OvcaID,SteviloSorojencev,Stanje,Opombe,Poreklo")] Oven oven)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oven);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", oven.OvcaID);
            ViewData["CredaID"] = new SelectList(_context.Crede, "CredeID", "CredeID", oven.CredaID);
            return View(oven);
        }

        // GET: Ovni/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oven = await _context.Ovni.FindAsync(id);
            if (oven == null)
            {
                return NotFound();
            }
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", oven.OvcaID);
            ViewData["CredaID"] = new SelectList(_context.Crede, "CredeID", "CredeID", oven.CredaID);
            return View(oven);
        }

        // POST: Ovni/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OvenID,CredaID,DatumRojstva,Pasma,OvcaID,SteviloSorojencev,Stanje,Opombe,Poreklo")] Oven oven)
        {
            if (id != oven.OvenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oven);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OvenExists(oven.OvenID))
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
            ViewData["OvcaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", oven.OvcaID);
            ViewData["CredaID"] = new SelectList(_context.Crede, "CredeID", "CredeID", oven.CredaID);
            return View(oven);
        }

        // GET: Ovni/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oven = await _context.Ovni
                .Include(o => o.Ovca)
                .Include(o => o.creda)
                .FirstOrDefaultAsync(m => m.OvenID == id);
            if (oven == null)
            {
                return NotFound();
            }

            return View(oven);
        }

        // POST: Ovni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var oven = await _context.Ovni.FindAsync(id);
            _context.Ovni.Remove(oven);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OvenExists(string id)
        {
            return _context.Ovni.Any(e => e.OvenID == id);
        }
    }
}
