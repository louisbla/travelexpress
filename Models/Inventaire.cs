using System;
using System.Collections.Generic;

namespace Garderie.Models
{
    public partial class Inventaire
    {
        public Inventaire()
        {
            Articles = new HashSet<Article>();
        }

        public int InventaireId { get; set; }
        public int? StockMax { get; set; }
        public int? StockActuel { get; set; }
        public int EmployeId { get; set; }
        public byte? Visible { get; set; }

        public Employe Employe { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
