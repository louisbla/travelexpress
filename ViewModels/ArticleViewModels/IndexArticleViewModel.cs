using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garderie.ViewModels.ArticleViewModels
{
    public class IndexArticleViewModel
    {
        public int ArticleId { get; set; }
        public string Nom { get; set; }
        [Display(Name = "Quantité")]
        public int Quantite { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        [Display(Name = "Catégorie")]
        public string Categorie { get; set; }
        public string MotCle { get; set; }

        public SelectList Categories { get; set; }
    }
}
