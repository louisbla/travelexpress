using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garderie.Models
{
    public partial class Facture
    {
        public Facture()
        {
            ParentsFactures = new HashSet<ParentFacture>();
        }

        public int FactureId { get; set; }
        [Display(Name = "Date d'émission")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateEmission { get; set; }
        [Display(Name = "Date de paiement")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DatePaiement { get; set; }
        [Display(Name = "Montant TTC")]
        public double? MontantTtc { get; set; }
        public byte? Visible { get; set; }
        public int StatutFactureId { get; set; }

        [Display(Name = "Statut")]
        public StatutFacture StatutFacture { get; set; }
        public ICollection<ParentFacture> ParentsFactures { get; set; }
    }
}
