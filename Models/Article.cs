using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garderie.Models
{
    public partial class Article
    {
        public int ArticleId { get; set; }
        public string Nom { get; set; }
        [Display(Name = "Quantité")]
        public int? Quantite { get; set; }
        public string Photo { get; set; }
        public byte? Visible { get; set; }
        public string Description { get; set; }
        public int? InventaireId { get; set; }
        public int? EnfantInventaireId { get; set; }
        public int CategorieId { get; set; }

        public CategorieArticle Categorie { get; set; }
        public InventaireEnfant EnfantInventaire { get; set; }
        public Inventaire Inventaire { get; set; }
    }
}
