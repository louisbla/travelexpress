using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Garderie.Models;

namespace Garderie.ViewModels.FactureViewModels
{
    public class DetailsFactureViewModel
    {
        public DetailsFactureViewModel()
        {
            Parents = new HashSet<Parent>();
        }

        public int FactureId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date d'émission")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateEmission { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de paiement")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DatePaiement { get; set; }

        [Display(Name = "Montant TTC")]
        public double? MontantTtc { get; set; }

        [Display(Name = "Statut")]
        public string StatutFacture { get; set; }

        [Display(Name = "Destinataire(s)")]
        public ICollection<Parent> Parents { get; set; }
    }
}
