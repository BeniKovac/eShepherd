using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Oven
    {
        
        [Key]
        public string OvenID { get; set; }
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

        public string Poreklo { get; set; }

    }
}