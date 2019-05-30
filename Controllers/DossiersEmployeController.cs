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
    public class DossiersEmployeController : Controller
    {
        private readonly GarderieContext _context;

        public DossiersEmployeController(GarderieContext context)
        {
            _context = context;
        }

        // GET: DossiersEmploye
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.DossiersEmploye.Include(d => d.Employe).Include(d => d.TypeContrat);
            return View(await garderieContext.ToListAsync());
        }

        // GET: DossiersEmploye/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossierEmploye = await _context.DossiersEmploye
                .Include(d => d.Employe)
                .Include(d => d.TypeContrat)
                .FirstOrDefaultAsync(m => m.DossierId == id);
            if (dossierEmploye == null)
            {
                return NotFound();
            }

            return View(dossierEmploye);
        }

        // GET: DossiersEmploye/Create
        public IActionResult Create()
        {
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId");
            ViewData["TypeContratId"] = new SelectList(_context.TypesContrat, "TypeContratId", "TypeContratId");
            return View();
        }

        // POST: DossiersEmploye/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DossierId,DateEntree,NbMoisAnciennete,TauxHoraireBrut,Visible,TypeContratId,EmployeId")] DossierEmploye dossierEmploye)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dossierEmploye);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", dossierEmploye.EmployeId);
            ViewData["TypeContratId"] = new SelectList(_context.TypesContrat, "TypeContratId", "TypeContratId", dossierEmploye.TypeContratId);
            return View(dossierEmploye);
        }

        // GET: DossiersEmploye/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossierEmploye = await _context.DossiersEmploye.FindAsync(id);
            if (dossierEmploye == null)
            {
                return NotFound();
            }
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", dossierEmploye.EmployeId);
            ViewData["TypeContratId"] = new SelectList(_context.TypesContrat, "TypeContratId", "TypeContratId", dossierEmploye.TypeContratId);
            return View(dossierEmploye);
        }

        // POST: DossiersEmploye/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DossierId,DateEntree,NbMoisAnciennete,TauxHoraireBrut,Visible,TypeContratId,EmployeId")] DossierEmploye dossierEmploye)
        {
            if (id != dossierEmploye.DossierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dossierEmploye);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DossierEmployeExists(dossierEmploye.DossierId))
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
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", dossierEmploye.EmployeId);
            ViewData["TypeContratId"] = new SelectList(_context.TypesContrat, "TypeContratId", "TypeContratId", dossierEmploye.TypeContratId);
            return View(dossierEmploye);
        }

        // GET: DossiersEmploye/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossierEmploye = await _context.DossiersEmploye
                .Include(d => d.Employe)
                .Include(d => d.TypeContrat)
                .FirstOrDefaultAsync(m => m.DossierId == id);
            if (dossierEmploye == null)
            {
                return NotFound();
            }

            return View(dossierEmploye);
        }

        // POST: DossiersEmploye/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dossierEmploye = await _context.DossiersEmploye.FindAsync(id);
            _context.DossiersEmploye.Remove(dossierEmploye);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DossierEmployeExists(int id)
        {
            return _context.DossiersEmploye.Any(e => e.DossierId == id);
        }
    }
}
