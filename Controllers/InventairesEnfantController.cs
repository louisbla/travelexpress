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
    public class InventairesEnfantController : Controller
    {
        private readonly GarderieContext _context;

        public InventairesEnfantController(GarderieContext context)
        {
            _context = context;
        }

        // GET: InventairesEnfant
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventairesEnfant.ToListAsync());
        }

        // GET: InventairesEnfant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventaireEnfant = await _context.InventairesEnfant
                .FirstOrDefaultAsync(m => m.InventaireId == id);
            if (inventaireEnfant == null)
            {
                return NotFound();
            }

            return View(inventaireEnfant);
        }

        // GET: InventairesEnfant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventairesEnfant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventaireId,Visible")] InventaireEnfant inventaireEnfant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventaireEnfant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventaireEnfant);
        }

        // GET: InventairesEnfant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventaireEnfant = await _context.InventairesEnfant.FindAsync(id);
            if (inventaireEnfant == null)
            {
                return NotFound();
            }
            return View(inventaireEnfant);
        }

        // POST: InventairesEnfant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventaireId,Visible")] InventaireEnfant inventaireEnfant)
        {
            if (id != inventaireEnfant.InventaireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventaireEnfant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventaireEnfantExists(inventaireEnfant.InventaireId))
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
            return View(inventaireEnfant);
        }

        // GET: InventairesEnfant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventaireEnfant = await _context.InventairesEnfant
                .FirstOrDefaultAsync(m => m.InventaireId == id);
            if (inventaireEnfant == null)
            {
                return NotFound();
            }

            return View(inventaireEnfant);
        }

        // POST: InventairesEnfant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventaireEnfant = await _context.InventairesEnfant.FindAsync(id);
            _context.InventairesEnfant.Remove(inventaireEnfant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventaireEnfantExists(int id)
        {
            return _context.InventairesEnfant.Any(e => e.InventaireId == id);
        }
    }
}
