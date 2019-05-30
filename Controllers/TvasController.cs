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
    public class TvasController : Controller
    {
        private readonly GarderieContext _context;

        public TvasController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Tvas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tvas.ToListAsync());
        }

        // GET: Tvas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tva = await _context.Tvas
                .FirstOrDefaultAsync(m => m.Tvaid == id);
            if (tva == null)
            {
                return NotFound();
            }

            return View(tva);
        }

        // GET: Tvas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tvas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tvaid,Nom,Valeur,Visible")] Tva tva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tva);
        }

        // GET: Tvas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tva = await _context.Tvas.FindAsync(id);
            if (tva == null)
            {
                return NotFound();
            }
            return View(tva);
        }

        // POST: Tvas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tvaid,Nom,Valeur,Visible")] Tva tva)
        {
            if (id != tva.Tvaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvaExists(tva.Tvaid))
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
            return View(tva);
        }

        // GET: Tvas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tva = await _context.Tvas
                .FirstOrDefaultAsync(m => m.Tvaid == id);
            if (tva == null)
            {
                return NotFound();
            }

            return View(tva);
        }

        // POST: Tvas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tva = await _context.Tvas.FindAsync(id);
            _context.Tvas.Remove(tva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvaExists(int id)
        {
            return _context.Tvas.Any(e => e.Tvaid == id);
        }
    }
}
