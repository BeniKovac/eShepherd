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
        [StringLength(10)]
        [Required]
        public string OvcaID { get; set; }

        [Display(Name = "Trenutna čreda")] 
        public int CredaID { get; set; }
        public Creda creda { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", NullDisplayText = "neznan", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum rojstva")]        
        public DateTime? DatumRojstva { get; set; }

        public string Pasma { get; set; }

        [StringLength(10)]
        [DisplayFormat(NullDisplayText = "neznan")]
        [Display(Name = "ID mame")] 
        public string? IdMame { get; set; }

        [DisplayFormat(NullDisplayText = "neznan")]
        [StringLength(10)]
        [Display(Name = "ID očeta")] 
        public string? IdOceta { get; set; }

        [DisplayFormat(NullDisplayText = "neznano")]
        [Display(Name = "Število sorojencev")] 
        public int? SteviloSorojencev { get; set; }

        public string? Stanje { get; set; }

        public string? Opombe { get; set; }

        [Display(Name = "Število dosedanjih kotitev")] 
        public int SteviloKotitev { get; set; }

        [Display(Name = "Povprečno število jagenjčkov na kotitev")] 
        public int PovprecjeJagenjckov { get; set; }

     
        public ICollection<Kotitev> SeznamKotitev { get; set; }

    }
}