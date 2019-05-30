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
    public class CongesController : Controller
    {
        private readonly GarderieContext _context;

        public CongesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Conges
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.Conges.Include(c => c.DossierEmploye).Include(c => c.TypeConge);
            return View(await garderieContext.ToListAsync());
        }

        // GET: Conges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conge = await _context.Conges
                .Include(c => c.DossierEmploye)
                .Include(c => c.TypeConge)
                .FirstOrDefaultAsync(m => m.CongeId == id);
            if (conge == null)
            {
                return NotFound();
            }

            return View(conge);
        }

        // GET: Conges/Create
        public IActionResult Create()
        {
            ViewData["DossierEmployeId"] = new SelectList(_context.DossiersEmploye, "DossierId", "DossierId");
            ViewData["TypeCongeId"] = new SelectList(_context.TypesConges, "TypeCongeId", "TypeCongeId");
            return View();
        }

        // POST: Conges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CongeId,Debut,Duree,TypeCongeId,Visible,DossierEmployeId")] Conge conge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DossierEmployeId"] = new SelectList(_context.DossiersEmploye, "DossierId", "DossierId", conge.DossierEmployeId);
            ViewData["TypeCongeId"] = new SelectList(_context.TypesConges, "TypeCongeId", "TypeCongeId", conge.TypeCongeId);
            return View(conge);
        }

        // GET: Conges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conge = await _context.Conges.FindAsync(id);
            if (conge == null)
            {
                return NotFound();
            }
            ViewData["DossierEmployeId"] = new SelectList(_context.DossiersEmploye, "DossierId", "DossierId", conge.DossierEmployeId);
            ViewData["TypeCongeId"] = new SelectList(_context.TypesConges, "TypeCongeId", "TypeCongeId", conge.TypeCongeId);
            return View(conge);
        }

        // POST: Conges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CongeId,Debut,Duree,TypeCongeId,Visible,DossierEmployeId")] Conge conge)
        {
            if (id != conge.CongeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongeExists(conge.CongeId))
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
            ViewData["DossierEmployeId"] = new SelectList(_context.DossiersEmploye, "DossierId", "DossierId", conge.DossierEmployeId);
            ViewData["TypeCongeId"] = new SelectList(_context.TypesConges, "TypeCongeId", "TypeCongeId", conge.TypeCongeId);
            return View(conge);
        }

        // GET: Conges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conge = await _context.Conges
                .Include(c => c.DossierEmploye)
                .Include(c => c.TypeConge)
                .FirstOrDefaultAsync(m => m.CongeId == id);
            if (conge == null)
            {
                return NotFound();
            }

            return View(conge);
        }

        // POST: Conges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conge = await _context.Conges.FindAsync(id);
            _context.Conges.Remove(conge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongeExists(int id)
        {
            return _context.Conges.Any(e => e.CongeId == id);
        }
    }
}
