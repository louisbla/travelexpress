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
    public class TypesCongeController : Controller
    {
        private readonly GarderieContext _context;

        public TypesCongeController(GarderieContext context)
        {
            _context = context;
        }

        // GET: TypesConge
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypesConges.ToListAsync());
        }

        // GET: TypesConge/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeConge = await _context.TypesConges
                .FirstOrDefaultAsync(m => m.TypeCongeId == id);
            if (typeConge == null)
            {
                return NotFound();
            }

            return View(typeConge);
        }

        // GET: TypesConge/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypesConge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeCongeId,Type")] TypeConge typeConge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeConge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeConge);
        }

        // GET: TypesConge/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeConge = await _context.TypesConges.FindAsync(id);
            if (typeConge == null)
            {
                return NotFound();
            }
            return View(typeConge);
        }

        // POST: TypesConge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeCongeId,Type")] TypeConge typeConge)
        {
            if (id != typeConge.TypeCongeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeConge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeCongeExists(typeConge.TypeCongeId))
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
            return View(typeConge);
        }

        // GET: TypesConge/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeConge = await _context.TypesConges
                .FirstOrDefaultAsync(m => m.TypeCongeId == id);
            if (typeConge == null)
            {
                return NotFound();
            }

            return View(typeConge);
        }

        // POST: TypesConge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeConge = await _context.TypesConges.FindAsync(id);
            _context.TypesConges.Remove(typeConge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeCongeExists(int id)
        {
            return _context.TypesConges.Any(e => e.TypeCongeId == id);
        }
    }
}
