using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garderie.Models;
using Microsoft.AspNetCore.Authorization;
using Garderie.Data;
using Garderie.ViewModels.EmployeViewModels;
using System.Text.RegularExpressions;

namespace Garderie.Controllers
{
    [Authorize]
    public class EmployesController : Controller
    {
        private readonly GarderieContext _context;
        Regex phoneRegex = new Regex(@"^\(?([0 - 9]{3})\)?[-. ]? ([0 - 9]{3})[-. ]? ([0 - 9]{4})$");

        public EmployesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Employes
        public async Task<IActionResult> Index()
        {
            List<IndexEmployeViewModel> employeVMList = new List<IndexEmployeViewModel>();
            var garderieContext = _context.Employes.Include(e => e.Personne);
            var employes = await garderieContext.ToListAsync();
            foreach(Employe employe in employes)
            {
                string externe = "Non";
                if(employe.Externe == 1)
                {
                    externe = "Oui";
                }
                IndexEmployeViewModel viewModel = new IndexEmployeViewModel
                {
                    EmployeId = employe.EmployeId,
                    Nom = employe.Personne.Nom,
                    Prenom = employe.Personne.Prenom,
                    Sexe = employe.Personne.Sexe,
                    NumSecu = employe.Personne.NumSecu,
                    DateNaissance = employe.Personne.DateNaissance,
                    Telephone = employe.Telephone,
                    Poste = employe.Poste,
                    Externe = externe
                };
                employeVMList.Add(viewModel);
            }
            return View(employeVMList);
        }

        // GET: Employes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employes
                .Include(e => e.Personne)
                .FirstOrDefaultAsync(m => m.EmployeId == id);
            if (employe == null)
            {
                return NotFound();
            }

            string externe = "Non";
            if (employe.Externe == 1)
            {
                externe = "Oui";
            }

            DetailsEmployeViewModel detailsEmployeViewModel = new DetailsEmployeViewModel
            {
                EmployeId = (int)id,
                Nom = employe.Personne.Nom,
                Prenom = employe.Personne.Prenom,
                Sexe = employe.Personne.Sexe,
                NumSecu = employe.Personne.NumSecu,
                DateNaissance = employe.Personne.DateNaissance,
                Telephone = employe.Telephone,
                Externe = externe,
                Poste = employe.Poste
            };

            return View(detailsEmployeViewModel);
        }

        // GET: Employes/Create
        public IActionResult Create()
        {
            CreateEmployeViewModel createEmployeViewModel = new CreateEmployeViewModel();
            return View(createEmployeViewModel);
        }

        // POST: Employes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeViewModel createEmployeViewModel)
        {
            if (ModelState.IsValid)
            {
                Personne personne = new Personne
                {
                    Nom = createEmployeViewModel.Nom,
                    Prenom = createEmployeViewModel.Prenom,
                    Sexe = createEmployeViewModel.Sexe,
                    DateNaissance = createEmployeViewModel.DateNaissance,
                    NumSecu = createEmployeViewModel.NumSecu,
                    Discriminator = "Employe"
                };
                _context.Add(personne);
                await _context.SaveChangesAsync();

                string telephone = phoneRegex.Replace(createEmployeViewModel.Telephone, "($1) $2-$3");

                Employe employe = new Employe
                {
                    EmployeId = personne.PersonneId,
                    Personne = personne,
                    Externe = createEmployeViewModel.Externe,
                    Poste = createEmployeViewModel.Poste,
                    Telephone = telephone
                };
                _context.Add(employe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createEmployeViewModel);
        }

        // GET: Employes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employes.Include(e => e.Personne).FirstOrDefaultAsync(e => e.EmployeId == id);
            if (employe == null)
            {
                return NotFound();
            }

            EditEmployeViewModel editEmployeViewModel = new EditEmployeViewModel
            {
                EmployeId = (int)id,
                Nom = employe.Personne.Nom,
                Prenom = employe.Personne.Prenom,
                Sexe = employe.Personne.Sexe,
                NumSecu = employe.Personne.NumSecu,
                DateNaissance = employe.Personne.DateNaissance,
                Telephone = employe.Telephone,
                Externe = (byte)employe.Externe,
                Poste = employe.Poste
            };
            return View(editEmployeViewModel);
        }

        // POST: Employes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditEmployeViewModel editEmployeViewModel)
        {
            if (id != editEmployeViewModel.EmployeId)
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
                        Nom = editEmployeViewModel.Nom,
                        Prenom = editEmployeViewModel.Prenom,
                        Sexe = editEmployeViewModel.Sexe,
                        DateNaissance = editEmployeViewModel.DateNaissance,
                        NumSecu = editEmployeViewModel.NumSecu,
                        Discriminator = "Employe"
                    };
                    _context.Update(personne);
                    await _context.SaveChangesAsync();

                    string telephone = phoneRegex.Replace(editEmployeViewModel.Telephone, "($1) $2-$3");

                    Employe employe = new Employe
                    {
                        EmployeId = id,
                        Personne = personne,
                        Externe = editEmployeViewModel.Externe,
                        Poste = editEmployeViewModel.Poste,
                        Telephone = telephone
                    };
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(editEmployeViewModel.EmployeId))
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
            return View(editEmployeViewModel);
        }

        // GET: Employes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employes
                .Include(e => e.Personne)
                .FirstOrDefaultAsync(m => m.EmployeId == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employe = await _context.Employes.FindAsync(id);
            _context.Employes.Remove(employe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeExists(int id)
        {
            return _context.Employes.Any(e => e.EmployeId == id);
        }
    }
}
