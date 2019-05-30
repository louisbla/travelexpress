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
    public class ParticipationsController : Controller
    {
        private readonly GarderieContext _context;

        public ParticipationsController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Participations
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.Participation.Include(p => p.Activite).Include(p => p.Groupe).Include(p => p.Salle);
            return View(await garderieContext.ToListAsync());
        }

        // GET: Participations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participation
                .Include(p => p.Activite)
                .Include(p => p.Groupe)
                .Include(p => p.Salle)
                .FirstOrDefaultAsync(m => m.ActiviteId == id);
            if (participation == null)
            {
                return NotFound();
            }

            return View(participation);
        }

        // GET: Participations/Create
        public IActionResult Create()
        {
            ViewData["ActiviteId"] = new SelectList(_context.Activites, "ActiviteId", "ActiviteId");
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId");
            ViewData["SalleId"] = new SelectList(_context.Lieux, "SalleId", "SalleId");
            return View();
        }

        // POST: Participations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,ActiviteId,GroupeId,SalleId,Visible")] Participation participation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActiviteId"] = new SelectList(_context.Activites, "ActiviteId", "ActiviteId", participation.ActiviteId);
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId", participation.GroupeId);
            ViewData["SalleId"] = new SelectList(_context.Lieux, "SalleId", "SalleId", participation.SalleId);
            return View(participation);
        }

        // GET: Participations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participation.FindAsync(id);
            if (participation == null)
            {
                return NotFound();
            }
            ViewData["ActiviteId"] = new SelectList(_context.Activites, "ActiviteId", "ActiviteId", participation.ActiviteId);
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId", participation.GroupeId);
            ViewData["SalleId"] = new SelectList(_context.Lieux, "SalleId", "SalleId", participation.SalleId);
            return View(participation);
        }

        // POST: Participations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,ActiviteId,GroupeId,SalleId,Visible")] Participation participation)
        {
            if (id != participation.ActiviteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipationExists(participation.ActiviteId))
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
            ViewData["ActiviteId"] = new SelectList(_context.Activites, "ActiviteId", "ActiviteId", participation.ActiviteId);
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId", participation.GroupeId);
            ViewData["SalleId"] = new SelectList(_context.Lieux, "SalleId", "SalleId", participation.SalleId);
            return View(participation);
        }

        // GET: Participations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participation = await _context.Participation
                .Include(p => p.Activite)
                .Include(p => p.Groupe)
                .Include(p => p.Salle)
                .FirstOrDefaultAsync(m => m.ActiviteId == id);
            if (participation == null)
            {
                return NotFound();
            }

            return View(participation);
        }

        // POST: Participations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participation = await _context.Participation.FindAsync(id);
            _context.Participation.Remove(participation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipationExists(int id)
        {
            return _context.Participation.Any(e => e.ActiviteId == id);
        }
    }
}
