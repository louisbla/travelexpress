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
    public class ActivitesController : Controller
    {
        private readonly GarderieContext _context;

        public ActivitesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Activites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Activites.ToListAsync());
        }

        // GET: Activites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activite = await _context.Activites
                .FirstOrDefaultAsync(m => m.ActiviteId == id);
            if (activite == null)
            {
                return NotFound();
            }

            return View(activite);
        }

        // GET: Activites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActiviteId,Nom,Description,NbEnfantsMax,Lieu,Visible")] Activite activite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activite);
        }

        // GET: Activites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activite = await _context.Activites.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }
            return View(activite);
        }

        // POST: Activites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActiviteId,Nom,Description,NbEnfantsMax,Lieu,Visible")] Activite activite)
        {
            if (id != activite.ActiviteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiviteExists(activite.ActiviteId))
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
            return View(activite);
        }

        // GET: Activites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activite = await _context.Activites
                .FirstOrDefaultAsync(m => m.ActiviteId == id);
            if (activite == null)
            {
                return NotFound();
            }

            return View(activite);
        }

        // POST: Activites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activite = await _context.Activites.FindAsync(id);
            _context.Activites.Remove(activite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiviteExists(int id)
        {
            return _context.Activites.Any(e => e.ActiviteId == id);
        }
    }
}
