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
    public class TypesGroupeController : Controller
    {
        private readonly GarderieContext _context;

        public TypesGroupeController(GarderieContext context)
        {
            _context = context;
        }

        // GET: TypesGroupe
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypesGroupe.ToListAsync());
        }

        // GET: TypesGroupe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesGroupe = await _context.TypesGroupe
                .FirstOrDefaultAsync(m => m.TypeGroupeId == id);
            if (typesGroupe == null)
            {
                return NotFound();
            }

            return View(typesGroupe);
        }

        // GET: TypesGroupe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypesGroupe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeGroupeId,Libelle")] TypeGroupe typesGroupe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typesGroupe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typesGroupe);
        }

        // GET: TypesGroupe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesGroupe = await _context.TypesGroupe.FindAsync(id);
            if (typesGroupe == null)
            {
                return NotFound();
            }
            return View(typesGroupe);
        }

        // POST: TypesGroupe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeGroupeId,Libelle")] TypeGroupe typesGroupe)
        {
            if (id != typesGroupe.TypeGroupeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typesGroupe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypesGroupeExists(typesGroupe.TypeGroupeId))
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
            return View(typesGroupe);
        }

        // GET: TypesGroupe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesGroupe = await _context.TypesGroupe
                .FirstOrDefaultAsync(m => m.TypeGroupeId == id);
            if (typesGroupe == null)
            {
                return NotFound();
            }

            return View(typesGroupe);
        }

        // POST: TypesGroupe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typesGroupe = await _context.TypesGroupe.FindAsync(id);
            _context.TypesGroupe.Remove(typesGroupe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypesGroupeExists(int id)
        {
            return _context.TypesGroupe.Any(e => e.TypeGroupeId == id);
        }
    }
}
