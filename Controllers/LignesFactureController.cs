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
    public class LignesFactureController : Controller
    {
        private readonly GarderieContext _context;

        public LignesFactureController(GarderieContext context)
        {
            _context = context;
        }

        // GET: LignesFacture
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.LignesFactures.Include(l => l.ObjetFacturable);
            return View(await garderieContext.ToListAsync());
        }

        // GET: LignesFacture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ligneFacture = await _context.LignesFactures
                .Include(l => l.ObjetFacturable)
                .FirstOrDefaultAsync(m => m.LigneId == id);
            if (ligneFacture == null)
            {
                return NotFound();
            }

            return View(ligneFacture);
        }

        // GET: LignesFacture/Create
        public IActionResult Create()
        {
            ViewData["ObjetFacturableId"] = new SelectList(_context.ObjetsFacturables, "ObjetFacturableId", "ObjetFacturableId");
            return View();
        }

        // POST: LignesFacture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LigneId,TotalHt,TotalTtc,Quantite,FactureId,ObjetFacturableId,Visible")] LigneFacture ligneFacture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ligneFacture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ObjetFacturableId"] = new SelectList(_context.ObjetsFacturables, "ObjetFacturableId", "ObjetFacturableId", ligneFacture.ObjetFacturableId);
            return View(ligneFacture);
        }

        // GET: LignesFacture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ligneFacture = await _context.LignesFactures.FindAsync(id);
            if (ligneFacture == null)
            {
                return NotFound();
            }
            ViewData["ObjetFacturableId"] = new SelectList(_context.ObjetsFacturables, "ObjetFacturableId", "ObjetFacturableId", ligneFacture.ObjetFacturableId);
            return View(ligneFacture);
        }

        // POST: LignesFacture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LigneId,TotalHt,TotalTtc,Quantite,FactureId,ObjetFacturableId,Visible")] LigneFacture ligneFacture)
        {
            if (id != ligneFacture.LigneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ligneFacture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LigneFactureExists(ligneFacture.LigneId))
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
            ViewData["ObjetFacturableId"] = new SelectList(_context.ObjetsFacturables, "ObjetFacturableId", "ObjetFacturableId", ligneFacture.ObjetFacturableId);
            return View(ligneFacture);
        }

        // GET: LignesFacture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ligneFacture = await _context.LignesFactures
                .Include(l => l.ObjetFacturable)
                .FirstOrDefaultAsync(m => m.LigneId == id);
            if (ligneFacture == null)
            {
                return NotFound();
            }

            return View(ligneFacture);
        }

        // POST: LignesFacture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ligneFacture = await _context.LignesFactures.FindAsync(id);
            _context.LignesFactures.Remove(ligneFacture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LigneFactureExists(int id)
        {
            return _context.LignesFactures.Any(e => e.LigneId == id);
        }
    }
}
