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
    public class FichesPayeController : Controller
    {
        private readonly GarderieContext _context;

        public FichesPayeController(GarderieContext context)
        {
            _context = context;
        }

        // GET: FaichesPaye
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.FichesPaye.Include(f => f.DossierEmploye);
            return View(await garderieContext.ToListAsync());
        }

        // GET: FaichesPaye/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichePaye = await _context.FichesPaye
                .Include(f => f.DossierEmploye)
                .FirstOrDefaultAsync(m => m.FichePayeId == id);
            if (fichePaye == null)
            {
                return NotFound();
            }

            return View(fichePaye);
        }

        // GET: FaichesPaye/Create
        public IActionResult Create()
        {
            ViewData["DossierEmployeId"] = new SelectList(_context.DossiersEmploye, "DossierId", "DossierId");
            return View();
        }

        // POST: FaichesPaye/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FichePayeId,SalaireBrut,NbHeuresPrevu,NbHeuresReel,DossierEmployeId,Visible")] FichePaye fichePaye)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fichePaye);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DossierEmployeId"] = new SelectList(_context.DossiersEmploye, "DossierId", "DossierId", fichePaye.DossierEmployeId);
            return View(fichePaye);
        }

        // GET: FaichesPaye/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichePaye = await _context.FichesPaye.FindAsync(id);
            if (fichePaye == null)
            {
                return NotFound();
            }
            ViewData["DossierEmployeId"] = new SelectList(_context.DossiersEmploye, "DossierId", "DossierId", fichePaye.DossierEmployeId);
            return View(fichePaye);
        }

        // POST: FaichesPaye/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FichePayeId,SalaireBrut,NbHeuresPrevu,NbHeuresReel,DossierEmployeId,Visible")] FichePaye fichePaye)
        {
            if (id != fichePaye.FichePayeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fichePaye);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichePayeExists(fichePaye.FichePayeId))
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
            ViewData["DossierEmployeId"] = new SelectList(_context.DossiersEmploye, "DossierId", "DossierId", fichePaye.DossierEmployeId);
            return View(fichePaye);
        }

        // GET: FaichesPaye/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichePaye = await _context.FichesPaye
                .Include(f => f.DossierEmploye)
                .FirstOrDefaultAsync(m => m.FichePayeId == id);
            if (fichePaye == null)
            {
                return NotFound();
            }

            return View(fichePaye);
        }

        // POST: FaichesPaye/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fichePaye = await _context.FichesPaye.FindAsync(id);
            _context.FichesPaye.Remove(fichePaye);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FichePayeExists(int id)
        {
            return _context.FichesPaye.Any(e => e.FichePayeId == id);
        }
    }
}
