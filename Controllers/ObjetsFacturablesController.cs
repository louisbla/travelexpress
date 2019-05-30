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
    public class ObjetsFacturablesController : Controller
    {
        private readonly GarderieContext _context;

        public ObjetsFacturablesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: ObjetsFacturables
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.ObjetsFacturables.Include(o => o.Activite).Include(o => o.Tva);
            return View(await garderieContext.ToListAsync());
        }

        // GET: ObjetsFacturables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetFacturable = await _context.ObjetsFacturables
                .Include(o => o.Activite)
                .Include(o => o.Tva)
                .FirstOrDefaultAsync(m => m.ObjetFacturableId == id);
            if (objetFacturable == null)
            {
                return NotFound();
            }

            return View(objetFacturable);
        }

        // GET: ObjetsFacturables/Create
        public IActionResult Create()
        {
            ViewData["ActiviteId"] = new SelectList(_context.Activites, "ActiviteId", "ActiviteId");
            ViewData["Tvaid"] = new SelectList(_context.Tvas, "Tvaid", "Tvaid");
            return View();
        }

        // POST: ObjetsFacturables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjetFacturableId,PrixHt,Nom,Tvaid,ActiviteId,Visible")] ObjetFacturable objetFacturable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objetFacturable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActiviteId"] = new SelectList(_context.Activites, "ActiviteId", "ActiviteId", objetFacturable.ActiviteId);
            ViewData["Tvaid"] = new SelectList(_context.Tvas, "Tvaid", "Tvaid", objetFacturable.Tvaid);
            return View(objetFacturable);
        }

        // GET: ObjetsFacturables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetFacturable = await _context.ObjetsFacturables.FindAsync(id);
            if (objetFacturable == null)
            {
                return NotFound();
            }
            ViewData["ActiviteId"] = new SelectList(_context.Activites, "ActiviteId", "ActiviteId", objetFacturable.ActiviteId);
            ViewData["Tvaid"] = new SelectList(_context.Tvas, "Tvaid", "Tvaid", objetFacturable.Tvaid);
            return View(objetFacturable);
        }

        // POST: ObjetsFacturables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObjetFacturableId,PrixHt,Nom,Tvaid,ActiviteId,Visible")] ObjetFacturable objetFacturable)
        {
            if (id != objetFacturable.ObjetFacturableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objetFacturable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetFacturableExists(objetFacturable.ObjetFacturableId))
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
            ViewData["ActiviteId"] = new SelectList(_context.Activites, "ActiviteId", "ActiviteId", objetFacturable.ActiviteId);
            ViewData["Tvaid"] = new SelectList(_context.Tvas, "Tvaid", "Tvaid", objetFacturable.Tvaid);
            return View(objetFacturable);
        }

        // GET: ObjetsFacturables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetFacturable = await _context.ObjetsFacturables
                .Include(o => o.Activite)
                .Include(o => o.Tva)
                .FirstOrDefaultAsync(m => m.ObjetFacturableId == id);
            if (objetFacturable == null)
            {
                return NotFound();
            }

            return View(objetFacturable);
        }

        // POST: ObjetsFacturables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objetFacturable = await _context.ObjetsFacturables.FindAsync(id);
            _context.ObjetsFacturables.Remove(objetFacturable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjetFacturableExists(int id)
        {
            return _context.ObjetsFacturables.Any(e => e.ObjetFacturableId == id);
        }
    }
}
