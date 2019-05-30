using Garderie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garderie.ViewModels.InventairesViewModels
{
    public class DetailsInventairesViewModel
    {
        public DetailsInventairesViewModel()
        {
            Articles = new HashSet<Article>();
        }
        public int InventaireId { get; set; }
        public int? StockMax { get; set; }
        public int? StockActuel { get; set; }
        public string Nom { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
