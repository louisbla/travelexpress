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
    public class DocumentsOfficielsController : Controller
    {
        private readonly GarderieContext _context;

        public DocumentsOfficielsController(GarderieContext context)
        {
            _context = context;
        }

        // GET: DocumentsOfficiels
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.DocumentsOfficiels.Include(d => d.Dossier);
            return View(await garderieContext.ToListAsync());
        }

        // GET: DocumentsOfficiels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentOfficiel = await _context.DocumentsOfficiels
                .Include(d => d.Dossier)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (documentOfficiel == null)
            {
                return NotFound();
            }

            return View(documentOfficiel);
        }

        // GET: DocumentsOfficiels/Create
        public IActionResult Create()
        {
            ViewData["DossierId"] = new SelectList(_context.DossiersInscription, "DossierId", "DossierId");
            return View();
        }

        // POST: DocumentsOfficiels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,Nom,Url,DossierId,Visible")] DocumentOfficiel documentOfficiel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentOfficiel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DossierId"] = new SelectList(_context.DossiersInscription, "DossierId", "DossierId", documentOfficiel.DossierId);
            return View(documentOfficiel);
        }

        // GET: DocumentsOfficiels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentOfficiel = await _context.DocumentsOfficiels.FindAsync(id);
            if (documentOfficiel == null)
            {
                return NotFound();
            }
            ViewData["DossierId"] = new SelectList(_context.DossiersInscription, "DossierId", "DossierId", documentOfficiel.DossierId);
            return View(documentOfficiel);
        }

        // POST: DocumentsOfficiels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,Nom,Url,DossierId,Visible")] DocumentOfficiel documentOfficiel)
        {
            if (id != documentOfficiel.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentOfficiel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentOfficielExists(documentOfficiel.DocumentId))
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
            ViewData["DossierId"] = new SelectList(_context.DossiersInscription, "DossierId", "DossierId", documentOfficiel.DossierId);
            return View(documentOfficiel);
        }

        // GET: DocumentsOfficiels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentOfficiel = await _context.DocumentsOfficiels
                .Include(d => d.Dossier)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (documentOfficiel == null)
            {
                return NotFound();
            }

            return View(documentOfficiel);
        }

        // POST: DocumentsOfficiels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentOfficiel = await _context.DocumentsOfficiels.FindAsync(id);
            _context.DocumentsOfficiels.Remove(documentOfficiel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentOfficielExists(int id)
        {
            return _context.DocumentsOfficiels.Any(e => e.DocumentId == id);
        }
    }
}
