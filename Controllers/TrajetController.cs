using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garderie.Models;
using Garderie.Data;
using Garderie.ViewModels.ArticleViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Garderie.Controllers
{
    public class TrajetController : Controller
    {
        private readonly GarderieContext _context;

        public IActionResult Index()
        {
            return View();
        }


        public TrajetController(GarderieContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,conducteur,ville_depart,ville_arrivee,date_heure,nb_passagers")] Trajet trajet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trajet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trajet);
        }
    }
}
