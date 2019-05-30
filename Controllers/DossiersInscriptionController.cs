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
    public class DossiersInscriptionController : Controller
    {
        private readonly GarderieContext _context;

        public DossiersInscriptionController(GarderieContext context)
        {
            _context = context;
        }

        // GET: DossiersInscription
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.DossiersInscription.Include(d => d.Enfant);
            return View(await garderieContext.ToListAsync());
        }

        // GET: DossiersInscription/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossierInscription = await _context.DossiersInscription
                .Include(d => d.Enfant)
                .FirstOrDefaultAsync(m => m.DossierId == id);
            if (dossierInscription == null)
            {
                return NotFound();
            }

            return View(dossierInscription);
        }

        // GET: DossiersInscription/Create
        public IActionResult Create()
        {
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId");
            return View();
        }

        // POST: DossiersInscription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DossierId,DateInscription,NbDemiJourneesInscrit,NbDemiJourneesAbsent,MedecinTraitant,EnfantId,Visible")] DossierInscription dossierInscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dossierInscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId", dossierInscription.EnfantId);
            return View(dossierInscription);
        }

        // GET: DossiersInscription/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossierInscription = await _context.DossiersInscription.FindAsync(id);
            if (dossierInscription == null)
            {
                return NotFound();
            }
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId", dossierInscription.EnfantId);
            return View(dossierInscription);
        }

        // POST: DossiersInscription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DossierId,DateInscription,NbDemiJourneesInscrit,NbDemiJourneesAbsent,MedecinTraitant,EnfantId,Visible")] DossierInscription dossierInscription)
        {
            if (id != dossierInscription.DossierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dossierInscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DossierInscriptionExists(dossierInscription.DossierId))
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
            ViewData["EnfantId"] = new SelectList(_context.Enfants, "EnfantId", "EnfantId", dossierInscription.EnfantId);
            return View(dossierInscription);
        }

        // GET: DossiersInscription/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossierInscription = await _context.DossiersInscription
                .Include(d => d.Enfant)
                .FirstOrDefaultAsync(m => m.DossierId == id);
            if (dossierInscription == null)
            {
                return NotFound();
            }

            return View(dossierInscription);
        }

        // POST: DossiersInscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dossierInscription = await _context.DossiersInscription.FindAsync(id);
            _context.DossiersInscription.Remove(dossierInscription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DossierInscriptionExists(int id)
        {
            return _context.DossiersInscription.Any(e => e.DossierId == id);
        }
    }
}
