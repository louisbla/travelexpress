using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Garderie.Models;

namespace Garderie.ViewModels.ArticleViewModels
{
    public class DetailsArticleViewModel
    {
        public DetailsArticleViewModel()
        {
            Enfants = new HashSet<Enfant>();
        }
        public int ArticleId { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Categorie { get; set; }

        [Display(Name = "Enfant")]
        public ICollection<Enfant> Enfants { get; set; }
    }
}
