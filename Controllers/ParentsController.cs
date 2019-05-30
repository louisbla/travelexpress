using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garderie.Models;
using Garderie.Data;
using Garderie.ViewModels.ParentViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Garderie.Controllers
{
    [Authorize]
    public class ParentsController : Controller
    {
        private readonly GarderieContext _context;

        public ParentsController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Parents
        public async Task<IActionResult> Index()
        {
            List<IndexParentViewModel> parentVMList = new List<IndexParentViewModel>();
            var garderieContext = _context.Parents.Include(p => p.Personne);
            var parents = await garderieContext.ToListAsync();
            foreach (Parent parent in parents)
            {
                IndexParentViewModel viewModel = new IndexParentViewModel
                {
                    ParentId = parent.ParentId,
                    Nom = parent.Personne.Nom,
                    Prenom = parent.Personne.Prenom,
                    Sexe = parent.Personne.Sexe,
                    NumSecu = parent.Personne.NumSecu,
                    DateNaissance = parent.Personne.DateNaissance,
                    Telephone = parent.Telephone
                };
                parentVMList.Add(viewModel);
            }
            return View(parentVMList);
        }

        // GET: Parents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parents.Include(p => p.Personne)
                                       .FirstOrDefaultAsync(p => p.ParentId == id);
            if (parent == null)
            {
                return NotFound();
            }

            var filiations = from f in _context.Filiations
                             join e in _context.Enfants on f.EnfantId equals e.EnfantId
                             join p in _context.Personnes on e.EnfantId equals p.PersonneId
                             where f.ParentId == id
                             select (new Enfant
                             {
                                 EnfantId = e.EnfantId,
                                 Photo = e.Photo,
                                 GroupeId = e.GroupeId,
                                 InventaireEnfantId = e.InventaireEnfantId,
                                 Personne = new Personne
                                 {
                                     Nom = p.Nom,
                                     Prenom = p.Prenom,
                                     NumSecu = p.NumSecu,
                                     Sexe = p.Sexe,
                                     DateNaissance = p.DateNaissance,
                                     Discriminator = p.Discriminator,
                                     Visible = p.Visible
                                 }
                             });

            DetailsParentViewModel detailsParentViewModel = new DetailsParentViewModel
            {
                ParentId = (int)id,
                Nom = parent.Personne.Nom,
                Prenom = parent.Personne.Prenom,
                Sexe = parent.Personne.Sexe,
                NumSecu = parent.Personne.NumSecu,
                DateNaissance = parent.Personne.DateNaissance,
                Telephone = parent.Telephone
            };

            foreach (var enfant in filiations)
            {
                detailsParentViewModel.Filiations.Add(enfant);
            }

            return View(detailsParentViewModel);
        }

        // GET: Parents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateParentViewModel createParentViewModel)
        {
            if (ModelState.IsValid)
            {
                Personne personne = new Personne
                {
                    Nom = createParentViewModel.Nom,
                    Prenom = createParentViewModel.Prenom,
                    Sexe = createParentViewModel.Sexe,
                    DateNaissance = createParentViewModel.DateNaissance,
                    NumSecu = createParentViewModel.NumSecu,
                    Discriminator = "Parent"
                };
                _context.Add(personne);
                await _context.SaveChangesAsync();

                Parent parent = new Parent
                {
                    ParentId = personne.PersonneId,
                    Personne = personne,
                    Telephone = createParentViewModel.Telephone
                };
                _context.Add(parent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createParentViewModel);
        }

        // GET: Parents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parents.Include(p => p.Personne).FirstOrDefaultAsync(p => p.ParentId == id);
            if (parent == null)
            {
                return NotFound();
            }

            EditParentViewModel editParentViewModel = new EditParentViewModel
            {
                ParentId = (int)id,
                Nom = parent.Personne.Nom,
                Prenom = parent.Personne.Prenom,
                Sexe = parent.Personne.Sexe,
                DateNaissance = parent.Personne.DateNaissance,
                NumSecu = parent.Personne.NumSecu,
                Telephone = parent.Telephone,
                NbEnfantsInscrits = (int)parent.NbEnfantsInscrits
            };
            return View(editParentViewModel);
        }

        // POST: Parents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditParentViewModel editParentViewModel)
        {
            if (id != editParentViewModel.ParentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Personne personne = new Personne
                    {
                        PersonneId = id,
                        Nom = editParentViewModel.Nom,
                        Prenom = editParentViewModel.Prenom,
                        Sexe = editParentViewModel.Sexe,
                        DateNaissance = editParentViewModel.DateNaissance,
                        NumSecu = editParentViewModel.NumSecu,
                        Discriminator = "Parent"
                    };
                    _context.Update(personne);
                    await _context.SaveChangesAsync();

                    Parent parent = new Parent
                    {
                        ParentId = id,
                        Personne = personne,
                        Telephone = editParentViewModel.Telephone,
                        NbEnfantsInscrits = editParentViewModel.NbEnfantsInscrits
                    };
                    _context.Update(parent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentExists(editParentViewModel.ParentId))
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
            return View(editParentViewModel);
        }

        // GET: Parents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parents
                .FirstOrDefaultAsync(m => m.ParentId == id);
            var personne = await _context.Personnes
                .FirstOrDefaultAsync(m => m.PersonneId == id);
            if (parent == null || personne == null)
            {
                return NotFound();
            }

            return View(parent);
        }

        // POST: Parents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parent = await _context.Parents.FindAsync(id);
            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();

            var user = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.PersonneId == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();


            var personne = await _context.Personnes.FindAsync(id);
            _context.Personnes.Remove(personne);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ParentExists(int id)
        {
            return _context.Parents.Any(e => e.ParentId == id);
        }
    }
}
