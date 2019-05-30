using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class CategorieArticle
    {
        public CategorieArticle()
        {
            Articles = new HashSet<Article>();
        }

        public int CategorieId { get; set; }
        public string Nom { get; set; }
        public byte? Visible { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
