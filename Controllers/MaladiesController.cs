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
    public class MaladiesController : Controller
    {
        private readonly GarderieContext _context;

        public MaladiesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Maladies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Maladies.ToListAsync());
        }

        // GET: Maladies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maladie = await _context.Maladies
                .FirstOrDefaultAsync(m => m.MaladieId == id);
            if (maladie == null)
            {
                return NotFound();
            }

            return View(maladie);
        }

        // GET: Maladies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maladies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaladieId,Nom,Descriptif,Visible")] Maladie maladie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maladie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maladie);
        }

        // GET: Maladies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maladie = await _context.Maladies.FindAsync(id);
            if (maladie == null)
            {
                return NotFound();
            }
            return View(maladie);
        }

        // POST: Maladies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaladieId,Nom,Descriptif,Visible")] Maladie maladie)
        {
            if (id != maladie.MaladieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maladie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaladieExists(maladie.MaladieId))
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
            return View(maladie);
        }

        // GET: Maladies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maladie = await _context.Maladies
                .FirstOrDefaultAsync(m => m.MaladieId == id);
            if (maladie == null)
            {
                return NotFound();
            }

            return View(maladie);
        }

        // POST: Maladies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maladie = await _context.Maladies.FindAsync(id);
            _context.Maladies.Remove(maladie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaladieExists(int id)
        {
            return _context.Maladies.Any(e => e.MaladieId == id);
        }
    }
}
