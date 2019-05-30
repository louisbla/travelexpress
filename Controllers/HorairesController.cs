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
    public class HorairesController : Controller
    {
        private readonly GarderieContext _context;

        public HorairesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Horaires
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.Horaires.Include(h => h.Calendrier);
            return View(await garderieContext.ToListAsync());
        }

        // GET: Horaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horaire = await _context.Horaires
                .Include(h => h.Calendrier)
                .FirstOrDefaultAsync(m => m.HoraireId == id);
            if (horaire == null)
            {
                return NotFound();
            }

            return View(horaire);
        }

        // GET: Horaires/Create
        public IActionResult Create()
        {
            ViewData["CalendrierId"] = new SelectList(_context.Calendriers, "CalendrierId", "CalendrierId");
            return View();
        }

        // POST: Horaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoraireId,Date,HeureDebut,HeureFin,CalendrierId,Visible,EmployeId")] Horaire horaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CalendrierId"] = new SelectList(_context.Calendriers, "CalendrierId", "CalendrierId", horaire.CalendrierId);
            return View(horaire);
        }

        // GET: Horaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horaire = await _context.Horaires.FindAsync(id);
            if (horaire == null)
            {
                return NotFound();
            }
            ViewData["CalendrierId"] = new SelectList(_context.Calendriers, "CalendrierId", "CalendrierId", horaire.CalendrierId);
            return View(horaire);
        }

        // POST: Horaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HoraireId,Date,HeureDebut,HeureFin,CalendrierId,Visible,EmployeId")] Horaire horaire)
        {
            if (id != horaire.HoraireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoraireExists(horaire.HoraireId))
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
            ViewData["CalendrierId"] = new SelectList(_context.Calendriers, "CalendrierId", "CalendrierId", horaire.CalendrierId);
            return View(horaire);
        }

        // GET: Horaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horaire = await _context.Horaires
                .Include(h => h.Calendrier)
                .FirstOrDefaultAsync(m => m.HoraireId == id);
            if (horaire == null)
            {
                return NotFound();
            }

            return View(horaire);
        }

        // POST: Horaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horaire = await _context.Horaires.FindAsync(id);
            _context.Horaires.Remove(horaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoraireExists(int id)
        {
            return _context.Horaires.Any(e => e.HoraireId == id);
        }
    }
}
