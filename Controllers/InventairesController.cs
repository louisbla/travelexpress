using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garderie.Models;
using Garderie.Data;
using Garderie.ViewModels.InventairesViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Garderie.Controllers
{
    [Authorize]
    public class InventairesController : Controller
    {
        private readonly GarderieContext _context;

        public InventairesController(GarderieContext context)
        {
            _context = context;
        }

        // GET: Inventaires
        public async Task<IActionResult> Index()
        {
            List<IndexInventairesViewModel> inventaireVMList = new List<IndexInventairesViewModel>();
            var garderieContext = _context.Inventaires.Include(i => i.Employe.Personne);
            var inventaires = await garderieContext.ToListAsync();

            foreach (Inventaire inventaire in inventaires)
            {
                IndexInventairesViewModel viewModel = new IndexInventairesViewModel
                {
                    InventaireId = inventaire.InventaireId,
                    StockMax = inventaire.StockMax,
                    StockActuel = inventaire.StockActuel,
                    Nom = inventaire.Employe.Personne.Prenom + " " + inventaire.Employe.Personne.Nom,
                };
                if (inventaire.Visible == 1)
                {
                    inventaireVMList.Add(viewModel);
                }
            }
            return View(inventaireVMList);
        }

        // GET: Inventaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventaire = await _context.Inventaires
                .Include(i => i.Employe.Personne)
                .FirstOrDefaultAsync(m => m.InventaireId == id);
            var articles = from a in _context.Articles
                           where a.InventaireId == id
                           select (new Article
                           {
                               ArticleId = a.ArticleId,
                               Nom = a.Nom,
                               Quantite = a.Quantite,
                               Photo = a.Photo
                           });

            DetailsInventairesViewModel detailsParentViewModel = new DetailsInventairesViewModel
            {
                InventaireId = (int)id,
                StockMax = inventaire.StockMax,
                StockActuel = inventaire.StockActuel,
                Nom = inventaire.Employe.Personne.Prenom + " " + inventaire.Employe.Personne.Nom,
            };

            foreach (Article article in articles)
            {
                detailsParentViewModel.Articles.Add(article);
            }

            if (inventaire == null)
            {
                return NotFound();
            }

            return View(detailsParentViewModel);
        }

        // GET: Inventaires/Create
        public IActionResult Create()
        {
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId");
            return View();
        }

        // POST: Inventaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventaireId,StockMax,StockActuel,EmployeId,Visible")] Inventaire inventaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", inventaire.EmployeId);
            return View(inventaire);
        }

        // GET: Inventaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventaire = await _context.Inventaires.FindAsync(id);
            if (inventaire == null)
            {
                return NotFound();
            }
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", inventaire.EmployeId);
            return View(inventaire);
        }

        // POST: Inventaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventaireId,StockMax,StockActuel,EmployeId,Visible")] Inventaire inventaire)
        {
            if (id != inventaire.InventaireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventaireExists(inventaire.InventaireId))
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
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", inventaire.EmployeId);
            return View(inventaire);
        }

        // GET: Inventaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventaire = await _context.Inventaires
                .Include(i => i.Employe)
                .FirstOrDefaultAsync(m => m.InventaireId == id);
            if (inventaire == null)
            {
                return NotFound();
            }

            return View(inventaire);
        }

        // POST: Inventaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventaire = await _context.Inventaires.FindAsync(id);
            _context.Inventaires.Remove(inventaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventaireExists(int id)
        {
            return _context.Inventaires.Any(e => e.InventaireId == id);
        }
    }
}
