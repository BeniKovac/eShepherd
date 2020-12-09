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

namespace web.Models.eShepherdViewModels
{
     [Authorize]
    public class CredeController : Controller
    {
        private readonly eShepherdContext _context;

        public CredeController(eShepherdContext context)
        {
            _context = context;
        }

        // GET: Crede
        public async Task<IActionResult> Index(int? credaID, string? ovcaID)
        {
            var viewModel = new CredeIndexData();
            viewModel.Crede = await _context.Crede
                            .Include(c => c.SeznamOvac)
                                .ThenInclude(c => c.OvcaID)
                            .ToListAsync();
                if (credaID != null)
                {
                    ViewData["CredeID"] = credaID.Value;
                    Creda creda = viewModel.Crede.Where(
                        c => c.CredeID == credaID.Value).Single();
                }
                if (ovcaID != null)
                {
                    ViewData["OvcaID"] = ovcaID;
                    viewModel.Ovce = viewModel.Ovce.Where(
                        x => x.OvcaID == ovcaID);
                }


    return View(viewModel);
           /* if (ovcaID != null) {
                 viewModel.Ovce = await _context.Ovce
                .Include(i => i.OvcaID)
                .OrderBy(i => i.OvcaID)
                .FirstOrDefaultAsync(m => m.OvcaID == ovcaID);
                // .ToListAsync();
            }

*/

            return View(await _context.Crede.ToListAsync());
        }

        // GET: Crede/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creda = await _context.Crede
                .FirstOrDefaultAsync(m => m.CredeID == id);
            if (creda == null)
            {
                return NotFound();
            }

            return View(creda);
        }

        // GET: Crede/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crede/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CredeID,SteviloOvc,Opombe")] Creda creda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creda);
        }

        // GET: Crede/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creda = await _context.Crede.FindAsync(id);
            if (creda == null)
            {
                return NotFound();
            }
            return View(creda);
        }

        // POST: Crede/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CredeID,SteviloOvc,Opombe")] Creda creda)
        {
            if (id != creda.CredeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CredaExists(creda.CredeID))
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
            return View(creda);
        }

        // GET: Crede/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creda = await _context.Crede
                .FirstOrDefaultAsync(m => m.CredeID == id);
            if (creda == null)
            {
                return NotFound();
            }

            return View(creda);
        }

        // POST: Crede/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creda = await _context.Crede.FindAsync(id);
            _context.Crede.Remove(creda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CredaExists(int id)
        {
            return _context.Crede.Any(e => e.CredeID == id);
        }
    }
}
