using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Oven
    {
        
        [Key]
        [Display(Name = "ID ovna")] 
        [StringLength(10)]
        [Required]
        public string OvenID { get; set; }

        public int CredaID { get; set; }
        public Creda creda { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "neznan", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum Rojstva")]        
        public DateTime? DatumRojstva { get; set; }

        [DisplayFormat(NullDisplayText = "neznan")]
        public string Pasma { get; set; }
        [Display(Name = "ID mame")] 
        public string? OvcaID { get; set; }
        public Ovca Ovca { get; set; }
        


        /* KAKO IMA LAHKO OVEN OVNA?*/
        //[DisplayFormat(NullDisplayText = "neznan")]
        
        [Display(Name = "ID očeta")] 
        public string? oceID { get; set; }
        public Oven oven { get; set; }

        [DisplayFormat(NullDisplayText = "neznano")]
        [Display(Name = "Število sorojencev")] 
        public int? SteviloSorojencev { get; set; }

        public string Stanje { get; set; }

        public string? Opombe { get; set; }

        public string Poreklo { get; set; }

    }
}