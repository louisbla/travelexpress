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
    public class TypesContratController : Controller
    {
        private readonly GarderieContext _context;

        public TypesContratController(GarderieContext context)
        {
            _context = context;
        }

        // GET: TypesContrat
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypesContrat.ToListAsync());
        }

        // GET: TypesContrat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeContrat = await _context.TypesContrat
                .FirstOrDefaultAsync(m => m.TypeContratId == id);
            if (typeContrat == null)
            {
                return NotFound();
            }

            return View(typeContrat);
        }

        // GET: TypesContrat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypesContrat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeContratId,Libelle")] TypeContrat typeContrat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeContrat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeContrat);
        }

        // GET: TypesContrat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeContrat = await _context.TypesContrat.FindAsync(id);
            if (typeContrat == null)
            {
                return NotFound();
            }
            return View(typeContrat);
        }

        // POST: TypesContrat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeContratId,Libelle")] TypeContrat typeContrat)
        {
            if (id != typeContrat.TypeContratId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeContrat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeContratExists(typeContrat.TypeContratId))
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
            return View(typeContrat);
        }

        // GET: TypesContrat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeContrat = await _context.TypesContrat
                .FirstOrDefaultAsync(m => m.TypeContratId == id);
            if (typeContrat == null)
            {
                return NotFound();
            }

            return View(typeContrat);
        }

        // POST: TypesContrat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeContrat = await _context.TypesContrat.FindAsync(id);
            _context.TypesContrat.Remove(typeContrat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeContratExists(int id)
        {
            return _context.TypesContrat.Any(e => e.TypeContratId == id);
        }
    }
}
