using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Kotitev
    {
        
        [Key]
        
        public int KotitevID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum kotitve")] 
        public DateTime DatumKotitve { get; set; }

        [Display(Name = "Število jagenjčkov")] 
        public int SteviloMladih { get; set; }

        [Display(Name = "Oven")]
        public string OvenID { get; set; }
        public Oven Oven { get; set; }
        
        [Display(Name = "Ovca")] 
        public string OvcaID { get; set; }
        public Ovca Ovca { get; set; }

        [Display(Name = "Število mrtvorojenih jagenjčkov")] 
        public int? SteviloMrtvih { get; set; }

        public string? Opombe { get; set; }

    }
}