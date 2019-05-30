using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garderie.Models;
using Garderie.Data;
using Microsoft.AspNetCore.Authorization;

namespace Garderie.Controllers
{
    [Authorize]
    public class FiliationsController : Controller
    {
        private readonly GarderieContext _context;

        public FiliationsController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Filiations
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.Filiations.Include(f => f.Enfant).Include(f => f.Parent);
            return View(await garderieContext.ToListAsync());
        }

        // GET: Filiations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiation = await _context.Filiations
                .Include(f => f.Enfant)
                .Include(f => f.Parent)
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (filiation == null)
            {
                return NotFound();
            }

            return View(filiation);
        }

        // GET: Filiations/Create
        public IActionResult Create()
        {
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId");
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "ParentId");
            return View();
        }

        // POST: Filiations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentId,EnfantId,LienParente,Visible")] Filiation filiation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId", filiation.EnfantId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "ParentId", filiation.ParentId);
            return View(filiation);
        }

        // GET: Filiations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiation = await _context.Filiations.FindAsync(id);
            if (filiation == null)
            {
                return NotFound();
            }
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId", filiation.EnfantId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "ParentId", filiation.ParentId);
            return View(filiation);
        }

        // POST: Filiations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParentId,EnfantId,LienParente,Visible")] Filiation filiation)
        {
            if (id != filiation.ParentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliationExists(filiation.ParentId))
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
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId", filiation.EnfantId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "ParentId", filiation.ParentId);
            return View(filiation);
        }

        // GET: Filiations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiation = await _context.Filiations
                .Include(f => f.Enfant)
                .Include(f => f.Parent)
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (filiation == null)
            {
                return NotFound();
            }

            return View(filiation);
        }

        // POST: Filiations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filiation = await _context.Filiations.FindAsync(id);
            _context.Filiations.Remove(filiation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliationExists(int id)
        {
            return _context.Filiations.Any(e => e.ParentId == id);
        }
    }
}
