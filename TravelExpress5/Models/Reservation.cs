using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExpress5.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de places")]
        public int NbPlaces { get; set; }
        public virtual ApplicationUser Passager { get; set; }
        public virtual Trajet Trajet { get; set; }
        
    }
}