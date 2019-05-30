using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garderie.Models;
using Garderie.Data;
using Garderie.ViewModels.CategoriesArticleViewModels;

namespace Garderie.Controllers
{
    public class CategoriesArticleController : Controller
    {
        private readonly GarderieContext _context;

        public CategoriesArticleController(GarderieContext context)
        {
            _context = context;
        }

        // GET: CategoriesArticle
        public async Task<IActionResult> Index()
        {
            ServiceReference2.GarderieServiceClient serv = new ServiceReference2.GarderieServiceClient();
            ServiceReference2.Categorie[] categories =  serv.GetAllCategoriesAsync().Result;
            

            List<IndexCategoriesArticleViewModel> categoriesArticleVMList = new List<IndexCategoriesArticleViewModel>();

            //var categories = await _context.CategoriesArticle.ToListAsync();
            foreach(ServiceReference2.Categorie categorie in categories)
            {
                IndexCategoriesArticleViewModel viewModel = new IndexCategoriesArticleViewModel
                {
                    CategorieId = categorie.idCategorie,
                    Nom = categorie.nom

                };
                categoriesArticleVMList.Add(viewModel);
            }

            return View(categoriesArticleVMList);
        }

        // GET: CategoriesArticle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieArticle = await _context.CategoriesArticle
               .FirstOrDefaultAsync(m => m.CategorieId == id);
            if (categorieArticle == null)
            {
                return NotFound();
            }

            var articles = from a in _context.Articles
                           join ca in _context.CategoriesArticle
                           on a.CategorieId equals ca.CategorieId
                           where a.CategorieId == id
                           select (new Article
                           {
                               ArticleId = a.ArticleId,
                               Nom = a.Nom,
                               Quantite = a.Quantite,
                               Photo = a.Photo,
                               Description = a.Description,
                               InventaireId = a.InventaireId,
                               EnfantInventaireId = a.EnfantInventaireId
                           });

            DetailsCategoriesArticleViewModel detailsCategorieArticleViewModel = new DetailsCategoriesArticleViewModel
            {
                CategorieId = categorieArticle.CategorieId,
                Nom = categorieArticle.Nom
            };

            foreach (var article in articles)
            {
                detailsCategorieArticleViewModel.Articles.Add(article);
            }

            return View(detailsCategorieArticleViewModel);
        }




        // GET: CategoriesArticle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriesArticle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategorieId,Nom,Visible")] CategorieArticle categorieArticle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorieArticle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorieArticle);
        }

        // GET: CategoriesArticle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieArticle = await _context.CategoriesArticle.FindAsync(id);
            if (categorieArticle == null)
            {
                return NotFound();
            }
            return View(categorieArticle);
        }

        // POST: CategoriesArticle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategorieId,Nom,Visible")] CategorieArticle categorieArticle)
        {
            if (id != categorieArticle.CategorieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorieArticle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieArticleExists(categorieArticle.CategorieId))
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
            return View(categorieArticle);
        }

        // GET: CategoriesArticle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieArticle = await _context.CategoriesArticle
                .FirstOrDefaultAsync(m => m.CategorieId == id);
            if (categorieArticle == null)
            {
                return NotFound();
            }

            return View(categorieArticle);
        }

        // POST: CategoriesArticle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorieArticle = await _context.CategoriesArticle.FindAsync(id);
            _context.CategoriesArticle.Remove(categorieArticle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieArticleExists(int id)
        {
            return _context.CategoriesArticle.Any(e => e.CategorieId == id);
        }
    }
}
