using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garderie.ViewModels.InventairesViewModels
{
    public class IndexInventairesViewModel
    {
        public int InventaireId { get; set; }
        public int? StockMax { get; set; }
        public int? StockActuel { get; set; }
        public string Nom { get; set; }
    }
}
