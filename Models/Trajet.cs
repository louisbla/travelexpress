using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Garderie.Models
{
    public class Trajet
    {
        public int id { get; set; }
        public int conducteur { get; set; }
        [Display(Name = "Ville de départ")]
        public String ville_depart { get; set; }
        [Display(Name = "Ville d'arrivée")]
        public String ville_arrivee { get; set; }
        public DateTime date_heure { get; set; }
        public int nb_passagers { get; set; }

    }
}
