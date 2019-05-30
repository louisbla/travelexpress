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
    public class PersonnesAdressesController : Controller
    {
        private readonly GarderieContext _context;

        public PersonnesAdressesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: PersonnesAdresses
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.PersonneAdresses.Include(p => p.Adresse).Include(p => p.Personne);
            return View(await garderieContext.ToListAsync());
        }

        // GET: PersonnesAdresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personneAdresse = await _context.PersonneAdresses
                .Include(p => p.Adresse)
                .Include(p => p.Personne)
                .FirstOrDefaultAsync(m => m.AdresseId == id);
            if (personneAdresse == null)
            {
                return NotFound();
            }

            return View(personneAdresse);
        }

        // GET: PersonnesAdresses/Create
        public IActionResult Create()
        {
            ViewData["AdresseId"] = new SelectList(_context.Adresses, "AdresseId", "AdresseId");
            ViewData["PersonneId"] = new SelectList(_context.Personnes, "PersonneId", "PersonneId");
            return View();
        }

        // POST: PersonnesAdresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdresseId,PersonneId,Domicile,Facturation,Visible")] PersonneAdresse personneAdresse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personneAdresse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresseId"] = new SelectList(_context.Adresses, "AdresseId", "AdresseId", personneAdresse.AdresseId);
            ViewData["PersonneId"] = new SelectList(_context.Personnes, "PersonneId", "PersonneId", personneAdresse.PersonneId);
            return View(personneAdresse);
        }

        // GET: PersonnesAdresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personneAdresse = await _context.PersonneAdresses.FindAsync(id);
            if (personneAdresse == null)
            {
                return NotFound();
            }
            ViewData["AdresseId"] = new SelectList(_context.Adresses, "AdresseId", "AdresseId", personneAdresse.AdresseId);
            ViewData["PersonneId"] = new SelectList(_context.Personnes, "PersonneId", "PersonneId", personneAdresse.PersonneId);
            return View(personneAdresse);
        }

        // POST: PersonnesAdresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdresseId,PersonneId,Domicile,Facturation,Visible")] PersonneAdresse personneAdresse)
        {
            if (id != personneAdresse.AdresseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personneAdresse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonneAdresseExists(personneAdresse.AdresseId))
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
            ViewData["AdresseId"] = new SelectList(_context.Adresses, "AdresseId", "AdresseId", personneAdresse.AdresseId);
            ViewData["PersonneId"] = new SelectList(_context.Personnes, "PersonneId", "PersonneId", personneAdresse.PersonneId);
            return View(personneAdresse);
        }

        // GET: PersonnesAdresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personneAdresse = await _context.PersonneAdresses
                .Include(p => p.Adresse)
                .Include(p => p.Personne)
                .FirstOrDefaultAsync(m => m.AdresseId == id);
            if (personneAdresse == null)
            {
                return NotFound();
            }

            return View(personneAdresse);
        }

        // POST: PersonnesAdresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personneAdresse = await _context.PersonneAdresses.FindAsync(id);
            _context.PersonneAdresses.Remove(personneAdresse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonneAdresseExists(int id)
        {
            return _context.PersonneAdresses.Any(e => e.AdresseId == id);
        }
    }
}
