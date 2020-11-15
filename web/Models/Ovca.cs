using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Ovca
    {
        
        [Key]
        [Display(Name = "ID ovce")] 
        public string OvcaID { get; set; }
        public Creda CredaID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum Rojstva")]        
        public DateTime? DatumRojstva { get; set; }

        public string Pasma { get; set; }

        [Display(Name = "ID mame")] 
        public string? IdMame { get; set; }

        [Display(Name = "ID očeta")] 
        public string? IdOceta { get; set; }

        [Display(Name = "Število sorojencev")] 
        public int? SteviloSorojencev { get; set; }

        public string Stanje { get; set; }

        public string? Opombe { get; set; }

        [Display(Name = "Število dosedanjih kotitev")] 
        public int SteviloKotitev { get; set; }

        [Display(Name = "Povprečno število jagenjčkov na kotitev")] 
        public int PovprecjeJagenjckov { get; set; }

        public ICollection<Kotitev> SeznamKotitev { get; set; }

    }
}