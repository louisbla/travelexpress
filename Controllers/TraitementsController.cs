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
    public class TraitementsController : Controller
    {
        private readonly GarderieContext _context;

        public TraitementsController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Traitements
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.Traitements.Include(t => t.Enfant).Include(t => t.Maladie);
            return View(await garderieContext.ToListAsync());
        }

        // GET: Traitements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traitement = await _context.Traitements
                .Include(t => t.Enfant)
                .Include(t => t.Maladie)
                .FirstOrDefaultAsync(m => m.MaladieId == id);
            if (traitement == null)
            {
                return NotFound();
            }

            return View(traitement);
        }

        // GET: Traitements/Create
        public IActionResult Create()
        {
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId");
            ViewData["MaladieId"] = new SelectList(_context.Maladies, "MaladieId", "MaladieId");
            return View();
        }

        // POST: Traitements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaladieId,EnfantId,NomMedicament,Specification,Type,Quantite,Frequence,Visible")] Traitement traitement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traitement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId", traitement.EnfantId);
            ViewData["MaladieId"] = new SelectList(_context.Maladies, "MaladieId", "MaladieId", traitement.MaladieId);
            return View(traitement);
        }

        // GET: Traitements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traitement = await _context.Traitements.FindAsync(id);
            if (traitement == null)
            {
                return NotFound();
            }
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId", traitement.EnfantId);
            ViewData["MaladieId"] = new SelectList(_context.Maladies, "MaladieId", "MaladieId", traitement.MaladieId);
            return View(traitement);
        }

        // POST: Traitements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaladieId,EnfantId,NomMedicament,Specification,Type,Quantite,Frequence,Visible")] Traitement traitement)
        {
            if (id != traitement.MaladieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traitement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraitementExists(traitement.MaladieId))
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
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId", traitement.EnfantId);
            ViewData["MaladieId"] = new SelectList(_context.Maladies, "MaladieId", "MaladieId", traitement.MaladieId);
            return View(traitement);
        }

        // GET: Traitements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traitement = await _context.Traitements
                .Include(t => t.Enfant)
                .Include(t => t.Maladie)
                .FirstOrDefaultAsync(m => m.MaladieId == id);
            if (traitement == null)
            {
                return NotFound();
            }

            return View(traitement);
        }

        // POST: Traitements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traitement = await _context.Traitements.FindAsync(id);
            _context.Traitements.Remove(traitement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraitementExists(int id)
        {
            return _context.Traitements.Any(e => e.MaladieId == id);
        }
    }
}
