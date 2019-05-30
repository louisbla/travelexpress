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
    public class RapportsJournaliersController : Controller
    {
        private readonly GarderieContext _context;

        public RapportsJournaliersController(GarderieContext context)
        {
            _context = context;
        }

        // GET: RapportsJournaliers
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.RapportJournalier.Include(r => r.DossierInscription);
            return View(await garderieContext.ToListAsync());
        }

        // GET: RapportsJournaliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapportJournalier = await _context.RapportJournalier
                .Include(r => r.DossierInscription)
                .FirstOrDefaultAsync(m => m.RapportId == id);
            if (rapportJournalier == null)
            {
                return NotFound();
            }

            return View(rapportJournalier);
        }

        // GET: RapportsJournaliers/Create
        public IActionResult Create()
        {
            ViewData["DossierInscriptionId"] = new SelectList(_context.DossiersInscription, "DossierId", "DossierId");
            return View();
        }

        // POST: RapportsJournaliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RapportId,Date,Present,Resume,Visible,DossierInscriptionId")] RapportJournalier rapportJournalier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapportJournalier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DossierInscriptionId"] = new SelectList(_context.DossiersInscription, "DossierId", "DossierId", rapportJournalier.DossierInscriptionId);
            return View(rapportJournalier);
        }

        // GET: RapportsJournaliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapportJournalier = await _context.RapportJournalier.FindAsync(id);
            if (rapportJournalier == null)
            {
                return NotFound();
            }
            ViewData["DossierInscriptionId"] = new SelectList(_context.DossiersInscription, "DossierId", "DossierId", rapportJournalier.DossierInscriptionId);
            return View(rapportJournalier);
        }

        // POST: RapportsJournaliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RapportId,Date,Present,Resume,Visible,DossierInscriptionId")] RapportJournalier rapportJournalier)
        {
            if (id != rapportJournalier.RapportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapportJournalier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapportJournalierExists(rapportJournalier.RapportId))
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
            ViewData["DossierInscriptionId"] = new SelectList(_context.DossiersInscription, "DossierId", "DossierId", rapportJournalier.DossierInscriptionId);
            return View(rapportJournalier);
        }

        // GET: RapportsJournaliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapportJournalier = await _context.RapportJournalier
                .Include(r => r.DossierInscription)
                .FirstOrDefaultAsync(m => m.RapportId == id);
            if (rapportJournalier == null)
            {
                return NotFound();
            }

            return View(rapportJournalier);
        }

        // POST: RapportsJournaliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rapportJournalier = await _context.RapportJournalier.FindAsync(id);
            _context.RapportJournalier.Remove(rapportJournalier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapportJournalierExists(int id)
        {
            return _context.RapportJournalier.Any(e => e.RapportId == id);
        }
    }
}
