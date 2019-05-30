using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garderie.Models;
using Garderie.ViewModels.GroupeViewModels;
using Garderie.Data;
using Microsoft.AspNetCore.Authorization;

namespace Garderie.Controllers
{
    [Authorize]
    public class GroupesController : Controller
    {
        private readonly GarderieContext _context;

        public GroupesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Groupes
        public async Task<IActionResult> Index()
        {
            List<IndexGroupeViewModel> GroupeVMList = new List<IndexGroupeViewModel>();
            var garderieContext = _context.Groupes.Include(g => g.Referant.Personne).Include(g => g.TypeGroupe);
            var groupes = await garderieContext.ToListAsync();
            foreach(var groupe in groupes)
            {
                IndexGroupeViewModel viewModel = new IndexGroupeViewModel
                {
                    GroupeId = groupe.GroupeId,
                    Descriptif = groupe.Descriptif,
                    Referant = groupe.Referant.Personne.Prenom + " " + groupe.Referant.Personne.Nom,
                    TypeGroupe = groupe.TypeGroupe.Libelle
                };
                GroupeVMList.Add(viewModel);
            }
            return View(GroupeVMList);
        }

        // GET: Groupes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupes
                .Include(g => g.Referant.Personne)
                .Include(g => g.TypeGroupe)
                .FirstOrDefaultAsync(m => m.GroupeId == id);
            DetailsGroupeViewModel viewModel = new DetailsGroupeViewModel();
            if (groupe == null)
            {
                return NotFound();
            }
            else
            {
                viewModel.GroupeId = groupe.GroupeId;
                viewModel.Descriptif = groupe.Descriptif;
                viewModel.Referant = groupe.Referant.Personne.Prenom + " " + groupe.Referant.Personne.Nom;
                viewModel.TypeGroupe = groupe.TypeGroupe.Libelle;
            }

            return View(viewModel);
        }

        // GET: Groupes/Create
        public IActionResult Create()
        {
            var employes = from e in _context.Employes
                           join p in _context.Personnes on e.EmployeId equals p.PersonneId
                           select (new
                           {
                                EmployeId = e.EmployeId,
                                Nom = p.Prenom + " " + p.Nom
                           });

            var createGroupeVM = new CreateGroupeViewModel();
            createGroupeVM.Referants = new SelectList(employes, "EmployeId", "Nom");
            createGroupeVM.TypesGroupe = new SelectList(_context.TypesGroupe, "TypeGroupeId", "Libelle");
            return View(createGroupeVM);
        }

        // POST: Groupes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGroupeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Groupe groupe = new Groupe();
                groupe.Descriptif = viewModel.Descriptif;
                groupe.ReferantId = viewModel.Referant;
                groupe.TypeGroupeId = viewModel.TypeGroupe;
                groupe.Visible = 1;
                _context.Add(groupe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
               
            }
            CreateGroupeViewModel createGroupeVM = new CreateGroupeViewModel
            {
                Referants = new SelectList(await _context.Employes.Include(e => e.Personne).Distinct().ToListAsync(), "EmployeId", "Personne.Nom", viewModel.Referant),
                TypesGroupe = new SelectList(_context.TypesGroupe, "TypeGroupeId", "Libelle", viewModel.TypeGroupe)
            };
            return View(createGroupeVM);
        }

        // GET: Groupes/Edit/5
        public async Task<IActionResult> Edit(int? id, EditGroupeViewModel viewModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupes.FindAsync(id);
            if (groupe == null)
            {
                return NotFound();
            }

            var employes = from e in _context.Employes
                           join p in _context.Personnes on e.EmployeId equals p.PersonneId
                           select (new
                           {
                               EmployeId = e.EmployeId,
                               Nom = p.Prenom + " " + p.Nom
                           });

            EditGroupeViewModel editGroupeVM = new EditGroupeViewModel
            {
                GroupeId = (int)id,
                Referants = new SelectList(employes, "EmployeId", "Nom"),
                TypesGroupe = new SelectList(_context.TypesGroupe, "TypeGroupeId", "Libelle")
            };
            return View(editGroupeVM);
        }

        // POST: Groupes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditGroupeViewModel viewModel)
        {
            if (id != viewModel.GroupeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Groupe groupe = new Groupe();
                    groupe.GroupeId = viewModel.GroupeId;
                    groupe.Descriptif = viewModel.Descriptif;
                    groupe.ReferantId = viewModel.Referant;
                    groupe.TypeGroupeId = viewModel.TypeGroupe;
                    groupe.Visible = 1;
                    _context.Update(groupe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupeExists(id))
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
            var editGroupeVM = new EditGroupeViewModel
            {
                GroupeId = (int)id,
                Referants = new SelectList(await _context.Employes.Include(e => e.Personne).Distinct().ToListAsync(), "EmployeId", "Personne.Nom", viewModel.Referant),
                TypesGroupe = new SelectList(_context.TypesGroupe, "TypeGroupeId", "Libelle", viewModel.TypeGroupe)
            };
            return View(editGroupeVM);
        }

        // GET: Groupes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupes
                .Include(g => g.Referant)
                .Include(g => g.TypeGroupe)
                .FirstOrDefaultAsync(m => m.GroupeId == id);
            if (groupe == null)
            {
                return NotFound();
            }

            return View(groupe);
        }

        // POST: Groupes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupe = await _context.Groupes.FindAsync(id);
            _context.Groupes.Remove(groupe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupeExists(int id)
        {
            return _context.Groupes.Any(e => e.GroupeId == id);
        }
    }
}
