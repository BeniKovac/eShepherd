using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace web.Controllers
{
    [Authorize]
    public class OvceController : Controller
    {
        private readonly eShepherdContext _context;

        public OvceController(eShepherdContext context)
        {
            _context = context;
        }

        // GET: Ovce
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ovce.ToListAsync());
        }

        // GET: Ovce/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ovca = await _context.Ovce
                .FirstOrDefaultAsync(m => m.OvcaID == id);
            if (ovca == null)
            {
                return NotFound();
            }

            return View(ovca);
        }

        // GET: Ovce/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ovce/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OvcaID,DatumRojstva,Pasma,IdMame,IdOceta,SteviloSorojencev,Stanje,Opombe,SteviloKotitev,PovprecjeJagenjckov")] Ovca ovca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ovca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ovca);
        }

        // GET: Ovce/Edit/5
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
            return View(ovca);
        }

        // POST: Ovce/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OvcaID,DatumRojstva,Pasma,IdMame,IdOceta,SteviloSorojencev,Stanje,Opombe,SteviloKotitev,PovprecjeJagenjckov")] Ovca ovca)
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
            return View(ovca);
        }

        // GET: Ovce/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ovca = await _context.Ovce
                .FirstOrDefaultAsync(m => m.OvcaID == id);
            if (ovca == null)
            {
                return NotFound();
            }

            return View(ovca);
        }

        // POST: Ovce/Delete/5
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
