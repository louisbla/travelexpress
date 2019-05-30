using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garderie.Data;
using Garderie.ViewModels.EnfantViewModels;
using Garderie.Models;

namespace Test.Controllers
{
    public class EnfantsController : Controller
    {
        private readonly GarderieContext _context;

        public EnfantsController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Enfants
        public async Task<IActionResult> Index()
        {
            var garderieContext = _context.Enfants
                                          .Include(e => e.Groupe)
                                          .Include(e => e.Groupe.TypeGroupe)
                                          .Include(e => e.InventaireEnfant)
                                          .Include(e => e.Personne);
            return View(await garderieContext.ToListAsync());
        }

        // GET: Enfants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiations = from f in _context.Filiations
                             join e in _context.Parents on f.ParentId equals e.ParentId
                             join p in _context.Personnes on e.ParentId equals p.PersonneId
                             where f.EnfantId == id
                             select (new Parent
                             {
                                 ParentId = e.ParentId,
                                 NbEnfantsInscrits = e.NbEnfantsInscrits,
                                 Telephone = e.Telephone,
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

            //var contacts_urgences = from d in _context.ContactsUrgence
            //join cont in _context.ContactsUrgence on d.ContactId equals cont.ContactId
            //join c in _context.Personnes on d.ContactId equals c.PersonneId
            //join doss in _context.DossiersInscription on d.DossierInscriptionId equals doss.DossierId
            //where doss.EnfantId == id;

            var enfant = await _context.Enfants
            .Include(e => e.Groupe)
            .Include(e => e.Groupe.TypeGroupe)
            .Include(e => e.InventaireEnfant)
            .Include(e => e.Personne)
            .FirstOrDefaultAsync(m => m.EnfantId == id);

            if (enfant == null)
            {
                return NotFound();
            }

            DetailsEnfantViewModel detailsEnfantViewModel = new DetailsEnfantViewModel()
            {
                EnfantId = enfant.EnfantId,
                Nom = enfant.Personne.Nom,
                Prenom = enfant.Personne.Prenom,
                Sexe = enfant.Personne.Sexe,
                NumSecu = enfant.Personne.NumSecu,
                DateNaissance = enfant.Personne.DateNaissance,
                Photo = enfant.Photo,
                Groupe = enfant.Groupe
            };

            //foreach (var contact in contacts_urgences)
            //{
            //    detailsEnfantViewModel.DossierContactUrgences.Add(contact);
            //}

            foreach (var parent in filiations)
            {
                detailsEnfantViewModel.Filiations.Add(parent);
            }

            return View(detailsEnfantViewModel);
        }

        // GET: Enfants/Create
        public IActionResult Create()
        {
            //ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId");
            //ViewData["InventaireEnfantId"] = new SelectList(_context.InventairesEnfant, "InventaireId", "InventaireId");

            var createEnfantVM = new CreateEnfantViewModel();
            createEnfantVM.Groupes = new SelectList(_context.Groupes, "GroupeId", "Descriptif");

            return View(createEnfantVM);
        }

        // POST: Enfants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEnfantViewModel createEnfantViewModel)
        {
            Personne personne = new Personne
            {
                Nom = createEnfantViewModel.Nom,
                Prenom = createEnfantViewModel.Prenom,
                Sexe = createEnfantViewModel.Sexe,
                DateNaissance = createEnfantViewModel.DateNaissance,
                NumSecu = createEnfantViewModel.NumSecu,
                Discriminator = "Enfant",
                Visible = 1
            };

            var groupe = await _context.Groupes.FirstOrDefaultAsync(m => m.GroupeId == createEnfantViewModel.GroupeId);
            Groupe groupeModel = new Groupe()
            {
                GroupeId = groupe.GroupeId,
                Descriptif = groupe.Descriptif
            };

            InventaireEnfant InventaireEnfant = new InventaireEnfant()
            {

            };

            Enfant enfant = new Enfant()
            {
                Photo = createEnfantViewModel.Photo,
                GroupeId = groupeModel.GroupeId

            };

            if (ModelState.IsValid)
            {
                _context.Add(personne);
                await _context.SaveChangesAsync();

                _context.Add(InventaireEnfant);
                await _context.SaveChangesAsync();

                enfant.InventaireEnfantId = InventaireEnfant.InventaireId;
                enfant.EnfantId = personne.PersonneId;
                _context.Add(enfant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId", enfant.GroupeId);
            ViewData["InventaireEnfantId"] = new SelectList(_context.InventairesEnfant, "InventaireId", "InventaireId", enfant.InventaireEnfantId);
            return View(enfant);
        }

        // GET: Enfants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var enfant = await _context.Enfants.Include(e => e.Personne).FirstOrDefaultAsync(e => e.EnfantId == id);
            var enfant = await _context.Enfants
                .Include(e => e.Groupe)
                .Include(e => e.Groupe.TypeGroupe)
                .Include(e => e.InventaireEnfant)
                .Include(e => e.Personne)
                .FirstOrDefaultAsync(m => m.EnfantId == id);

            if (enfant == null)
            {
                return NotFound();
            }

            EditEnfantViewModel editEnfantViewModel = new EditEnfantViewModel()
            {
                EnfantId = enfant.EnfantId,
                Nom = enfant.Personne.Nom,
                Prenom = enfant.Personne.Prenom,
                Sexe = enfant.Personne.Sexe,
                NumSecu = enfant.Personne.NumSecu,
                DateNaissance = enfant.Personne.DateNaissance,
                Photo = enfant.Photo,
                Groupe = enfant.Groupe
            };

            //ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId", enfant.GroupeId);
            //ViewData["InventaireEnfantId"] = new SelectList(_context.InventairesEnfant, "InventaireId", "InventaireId", enfant.InventaireEnfantId);
            return View(editEnfantViewModel);
        }

        // POST: Enfants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEnfantViewModel editEnfantViewModel)
        {
            if (id != editEnfantViewModel.EnfantId)
            {
                return NotFound();
            }

            Enfant enfant = new Enfant()
            {

            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfantExists(enfant.EnfantId))
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
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "GroupeId", "GroupeId", enfant.GroupeId);
            ViewData["InventaireEnfantId"] = new SelectList(_context.InventairesEnfant, "InventaireId", "InventaireId", enfant.InventaireEnfantId);
            return View(enfant);
        }

        // GET: Enfants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfant = await _context.Enfants
                .Include(e => e.Groupe)
                .Include(e => e.InventaireEnfant)
                .FirstOrDefaultAsync(m => m.EnfantId == id);
            if (enfant == null)
            {
                return NotFound();
            }

            return View(enfant);
        }

        // POST: Enfants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enfant = await _context.Enfants.FindAsync(id);
            _context.Enfants.Remove(enfant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfantExists(int id)
        {
            return _context.Enfants.Any(e => e.EnfantId == id);
        }
    }
}
