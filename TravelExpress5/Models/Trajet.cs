using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExpress5.Models
{
    public class Trajet
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        [Display(Name = "Date de départ")]
        public DateTime DateDepart { get; set; }
        [Display(Name = "Places totales")]
        public int NbPlacesMax { get; set; }
        [Display(Name = "Ville de départ")]
        public string VilleDepart { get; set; }
        [Display(Name = "Ville d'arrivée")]
        public string VilleArrivee { get; set; }
        [Display(Name = "Prix")]
        public double Prix { get; set; }
        virtual public ICollection<Reservation> Passagers { get; set; }
        virtual public ApplicationUser Conducteur { get; set; }

        public int NbPlacesLibres()
        {
            int placesReservees = 0;
            foreach(Reservation res in Passagers)
            {
                placesReservees += res.NbPlaces;
            }

            return NbPlacesMax - placesReservees;
        }
    }
}