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
    public class EmployesGroupesController : Controller
    {
        private readonly GarderieContext _context;

        public EmployesGroupesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: EmployesGroupes
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.EmployeGroupes
                                          .Include(e => e.Employe)
                                          .Include(e => e.Employe.Personne)
                                          .Include(e => e.Groupe.TypeGroupe);
            return View(await garderieContext.ToListAsync());
        }

        // GET: EmployesGroupes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeGroupe = await _context.EmployeGroupes
                .Include(e => e.Employe)
                .Include(e => e.Groupe)
                .FirstOrDefaultAsync(m => m.GroupeId == id);
            if (employeGroupe == null)
            {
                return NotFound();
            }

            return View(employeGroupe);
        }

        // GET: EmployesGroupes/Create
        public IActionResult Create()
        {
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId");
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId");
            return View();
        }

        // POST: EmployesGroupes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupeId,EmployeId")] EmployeGroupe employeGroupe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeGroupe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", employeGroupe.EmployeId);
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId", employeGroupe.GroupeId);
            return View(employeGroupe);
        }

        // GET: EmployesGroupes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeGroupe = await _context.EmployeGroupes.FindAsync(id);
            if (employeGroupe == null)
            {
                return NotFound();
            }
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", employeGroupe.EmployeId);
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId", employeGroupe.GroupeId);
            return View(employeGroupe);
        }

        // POST: EmployesGroupes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupeId,EmployeId")] EmployeGroupe employeGroupe)
        {
            if (id != employeGroupe.GroupeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeGroupe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeGroupeExists(employeGroupe.GroupeId))
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
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", employeGroupe.EmployeId);
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId", employeGroupe.GroupeId);
            return View(employeGroupe);
        }

        // GET: EmployesGroupes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeGroupe = await _context.EmployeGroupes
                .Include(e => e.Employe)
                .Include(e => e.Groupe)
                .FirstOrDefaultAsync(m => m.GroupeId == id);
            if (employeGroupe == null)
            {
                return NotFound();
            }

            return View(employeGroupe);
        }

        // POST: EmployesGroupes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeGroupe = await _context.EmployeGroupes.FindAsync(id);
            _context.EmployeGroupes.Remove(employeGroupe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeGroupeExists(int id)
        {
            return _context.EmployeGroupes.Any(e => e.GroupeId == id);
        }
    }
}
