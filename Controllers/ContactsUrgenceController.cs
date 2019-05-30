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
    public class ContactsUrgenceController : Controller
    {
        private readonly GarderieContext _context;

        public ContactsUrgenceController(GarderieContext context)
        {
            _context = context;
        }

        // GET: ContactsUrgence
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactsUrgence.ToListAsync());
        }

        // GET: ContactsUrgence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUrgence = await _context.ContactsUrgence
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contactUrgence == null)
            {
                return NotFound();
            }

            return View(contactUrgence);
        }

        // GET: ContactsUrgence/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactsUrgence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,Telephone")] ContactUrgence contactUrgence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactUrgence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactUrgence);
        }

        // GET: ContactsUrgence/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUrgence = await _context.ContactsUrgence.FindAsync(id);
            if (contactUrgence == null)
            {
                return NotFound();
            }
            return View(contactUrgence);
        }

        // POST: ContactsUrgence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,Telephone")] ContactUrgence contactUrgence)
        {
            if (id != contactUrgence.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactUrgence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactUrgenceExists(contactUrgence.ContactId))
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
            return View(contactUrgence);
        }

        // GET: ContactsUrgence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUrgence = await _context.ContactsUrgence
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contactUrgence == null)
            {
                return NotFound();
            }

            return View(contactUrgence);
        }

        // POST: ContactsUrgence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactUrgence = await _context.ContactsUrgence.FindAsync(id);
            _context.ContactsUrgence.Remove(contactUrgence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactUrgenceExists(int id)
        {
            return _context.ContactsUrgence.Any(e => e.ContactId == id);
        }
    }
}
