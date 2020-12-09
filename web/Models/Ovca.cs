using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Ovca
    {
        
        public Ovca()
        {
            SeznamKotitev = new List<Kotitev>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID ovce")] 
        [StringLength(10)]
        [Required]
        public string OvcaID { get; set; }

        [Display(Name = "Trenutna čreda")] 
        public int CredaID { get; set; }
        [Display(Name = "Trenutna čreda")] 
        public Creda creda { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", NullDisplayText = "/", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum rojstva")]        
        public DateTime? DatumRojstva { get; set; }

        public string Pasma { get; set; }

        [DisplayFormat(NullDisplayText = "/")]
        [Display(Name = "ID mame")] 
        public string? mamaID { get; set; }
        [Display(Name = "ID mame")] 
        public Ovca mama { get; set; }

        [StringLength(10)]
        [DisplayFormat(NullDisplayText = "/")]
        [Display(Name = "ID očeta")] 
        public Oven oce { get; set; }
        [Display(Name = "ID očeta")] 

        public string? oceID { get; set; }
 
        [DisplayFormat(NullDisplayText = "/")]
        [Display(Name = "Število sorojencev")] 
        public int? SteviloSorojencev { get; set; }

        [DisplayFormat(NullDisplayText = "/")]
        public string? Stanje { get; set; }

        [DisplayFormat(NullDisplayText = "/")]
        public string? Opombe { get; set; }
        [DisplayFormat(NullDisplayText = "0")]

        [Display(Name = "Število dosedanjih kotitev")] 
        public int SteviloKotitev { 
            get
                {
                    return SeznamKotitev.Count;
                } 
        }

        [DisplayFormat(NullDisplayText = "0")]
        [Display(Name = "Povprečno število jagenjčkov na kotitev")] 
        public int PovprecjeJagenjckov { 
            get
                {
                    if (SteviloKotitev == 0) {
                        return 0;
                    }
                    int jagenjcki = 0;
                    foreach (var kotitev in SeznamKotitev) {
                        jagenjcki += kotitev.SteviloMladih;
                    }
                    return jagenjcki / SteviloKotitev;
                    
                }
            }

        public ICollection<Kotitev>? SeznamKotitev { get; set; }
        public ICollection<Gonitev> SeznamGonitev { get; set; }


    }
}