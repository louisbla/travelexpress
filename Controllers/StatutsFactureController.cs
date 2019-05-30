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
    public class StatutsFactureController : Controller
    {
        private readonly GarderieContext _context;

        public StatutsFactureController(GarderieContext context)
        {
            _context = context;
        }

        // GET: StatutsFacture
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatutsFacture.ToListAsync());
        }

        // GET: StatutsFacture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statutFacture = await _context.StatutsFacture
                .FirstOrDefaultAsync(m => m.StatutFactureId == id);
            if (statutFacture == null)
            {
                return NotFound();
            }

            return View(statutFacture);
        }

        // GET: StatutsFacture/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatutsFacture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatutFactureId,Libelle")] StatutFacture statutFacture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statutFacture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statutFacture);
        }

        // GET: StatutsFacture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statutFacture = await _context.StatutsFacture.FindAsync(id);
            if (statutFacture == null)
            {
                return NotFound();
            }
            return View(statutFacture);
        }

        // POST: StatutsFacture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatutFactureId,Libelle")] StatutFacture statutFacture)
        {
            if (id != statutFacture.StatutFactureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statutFacture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatutFactureExists(statutFacture.StatutFactureId))
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
            return View(statutFacture);
        }

        // GET: StatutsFacture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statutFacture = await _context.StatutsFacture
                .FirstOrDefaultAsync(m => m.StatutFactureId == id);
            if (statutFacture == null)
            {
                return NotFound();
            }

            return View(statutFacture);
        }

        // POST: StatutsFacture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statutFacture = await _context.StatutsFacture.FindAsync(id);
            _context.StatutsFacture.Remove(statutFacture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatutFactureExists(int id)
        {
            return _context.StatutsFacture.Any(e => e.StatutFactureId == id);
        }
    }
}
