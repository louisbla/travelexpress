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
    public class LieuxController : Controller
    {
        private readonly GarderieContext _context;

        public LieuxController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Lieux
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lieux.ToListAsync());
        }

        // GET: Lieux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lieu = await _context.Lieux
                .FirstOrDefaultAsync(m => m.SalleId == id);
            if (lieu == null)
            {
                return NotFound();
            }

            return View(lieu);
        }

        // GET: Lieux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lieux/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalleId,Libelle,Occupe,Visible")] Lieu lieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lieu);
        }

        // GET: Lieux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lieu = await _context.Lieux.FindAsync(id);
            if (lieu == null)
            {
                return NotFound();
            }
            return View(lieu);
        }

        // POST: Lieux/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalleId,Libelle,Occupe,Visible")] Lieu lieu)
        {
            if (id != lieu.SalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LieuExists(lieu.SalleId))
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
            return View(lieu);
        }

        // GET: Lieux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lieu = await _context.Lieux
                .FirstOrDefaultAsync(m => m.SalleId == id);
            if (lieu == null)
            {
                return NotFound();
            }

            return View(lieu);
        }

        // POST: Lieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lieu = await _context.Lieux.FindAsync(id);
            _context.Lieux.Remove(lieu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LieuExists(int id)
        {
            return _context.Lieux.Any(e => e.SalleId == id);
        }
    }
}
