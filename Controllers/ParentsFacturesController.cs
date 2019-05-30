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
    public class ParentsFacturesController : Controller
    {
        private readonly GarderieContext _context;

        public ParentsFacturesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: ParentsFactures
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.ParentsFactures.Include(p => p.Facture).Include(p => p.Parent);
            return View(await garderieContext.ToListAsync());
        }

        // GET: ParentsFactures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentFacture = await _context.ParentsFactures
                .Include(p => p.Facture)
                .Include(p => p.Parent)
                .FirstOrDefaultAsync(m => m.FactureId == id);
            if (parentFacture == null)
            {
                return NotFound();
            }

            return View(parentFacture);
        }

        // GET: ParentsFactures/Create
        public IActionResult Create()
        {
            ViewData["FactureId"] = new SelectList(_context.Factures, "FactureId", "FactureId");
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "ParentId");
            return View();
        }

        // POST: ParentsFactures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FactureId,ParentId,Visible")] ParentFacture parentFacture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parentFacture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FactureId"] = new SelectList(_context.Factures, "FactureId", "FactureId", parentFacture.FactureId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "ParentId", parentFacture.ParentId);
            return View(parentFacture);
        }

        // GET: ParentsFactures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentFacture = await _context.ParentsFactures.FindAsync(id);
            if (parentFacture == null)
            {
                return NotFound();
            }
            ViewData["FactureId"] = new SelectList(_context.Factures, "FactureId", "FactureId", parentFacture.FactureId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "ParentId", parentFacture.ParentId);
            return View(parentFacture);
        }

        // POST: ParentsFactures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FactureId,ParentId,Visible")] ParentFacture parentFacture)
        {
            if (id != parentFacture.FactureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parentFacture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentFactureExists(parentFacture.FactureId))
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
            ViewData["FactureId"] = new SelectList(_context.Factures, "FactureId", "FactureId", parentFacture.FactureId);
            ViewData["ParentId"] = new SelectList(_context.Parents, "ParentId", "ParentId", parentFacture.ParentId);
            return View(parentFacture);
        }

        // GET: ParentsFactures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentFacture = await _context.ParentsFactures
                .Include(p => p.Facture)
                .Include(p => p.Parent)
                .FirstOrDefaultAsync(m => m.FactureId == id);
            if (parentFacture == null)
            {
                return NotFound();
            }

            return View(parentFacture);
        }

        // POST: ParentsFactures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parentFacture = await _context.ParentsFactures.FindAsync(id);
            _context.ParentsFactures.Remove(parentFacture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentFactureExists(int id)
        {
            return _context.ParentsFactures.Any(e => e.FactureId == id);
        }
    }
}
