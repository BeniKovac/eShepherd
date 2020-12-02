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
    public class OvceController : Controller
    {
        private readonly eShepherdContext _context;

        public OvceController(eShepherdContext context)
        {
            _context = context;
        }

        // GET: Ovce3
        public async Task<IActionResult> Index()
        {
            var eShepherdContext = _context.Ovce.Include(o => o.creda).Include(o => o.mama);//.Include(o => o.oce);
            return View(await eShepherdContext.ToListAsync());
        }

        // GET: Ovce3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ovca = await _context.Ovce
                .Include(o => o.creda)
                .Include(o => o.mama)
                .Include(o => o.oce)
                .FirstOrDefaultAsync(m => m.OvcaID == id);
            if (ovca == null)
            {
                return NotFound();
            }

            return View(ovca);
        }

        // GET: Ovce3/Create
        public IActionResult Create()
        {
            ViewData["CredaID"] = new SelectList(_context.Crede, "CredeID", "CredeID");
            ViewData["mamaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID");
            ViewData["oceID"] = new SelectList(_context.Ovni, "OvenID", "OvenID");

            return View();
        }

        // POST: Ovce3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OvcaID,CredaID,DatumRojstva,Pasma,mamaID,oceID,SteviloSorojencev,Stanje,Opombe,SteviloKotitev,PovprecjeJagenjckov")] Ovca ovca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ovca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CredaID"] = new SelectList(_context.Crede, "CredeID", "CredeID", ovca.CredaID);
            ViewData["mamaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", ovca.mamaID);
            ViewData["oceID"] = new SelectList(_context.Ovni, "OvenID", "OvenID", ovca.oceID);

            return View(ovca);
        }

        // GET: Ovce3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ovca = await _context.Ovce.FindAsync(id);
            if (ovca == null)
            {
                return NotFound();
            }
            ViewData["CredaID"] = new SelectList(_context.Crede, "CredeID", "CredeID", ovca.CredaID);
            ViewData["mamaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", ovca.mamaID);
            ViewData["oceID"] = new SelectList(_context.Ovni, "OvenID", "OvenID", ovca.oceID);

            return View(ovca);
        }

        // POST: Ovce3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OvcaID,CredaID,DatumRojstva,Pasma, mamaID,oceID, SteviloSorojencev,Stanje,Opombe,SteviloKotitev,PovprecjeJagenjckov")] Ovca ovca)
        {
            if (id != ovca.OvcaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ovca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OvcaExists(ovca.OvcaID))
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
            ViewData["CredaID"] = new SelectList(_context.Crede, "CredeID", "CredeID", ovca.CredaID);
            ViewData["mamaID"] = new SelectList(_context.Ovce, "OvcaID", "OvcaID", ovca.mamaID);
            ViewData["oceID"] = new SelectList(_context.Ovni, "OvenID", "OvenID", ovca.oceID);

            return View(ovca);
        }

        // GET: Ovce3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ovca = await _context.Ovce
                .Include(o => o.creda)
                .Include(o => o.mama)
                .Include(o => o.oce)
                .FirstOrDefaultAsync(m => m.OvcaID == id);
            if (ovca == null)
            {
                return NotFound();
            }

            return View(ovca);
        }

        // POST: Ovce3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ovca = await _context.Ovce.FindAsync(id);
            _context.Ovce.Remove(ovca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OvcaExists(string id)
        {
            return _context.Ovce.Any(e => e.OvcaID == id);
        }
    }
}
