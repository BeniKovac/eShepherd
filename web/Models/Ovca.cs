using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Ovca
    {
        
        [Key]
        public string OvcaID { get; set; }
        public Creda CredaID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DatumRojstva")]        
        public DateTime DatumRojstva { get; set; }
        public string Pasma { get; set; }
        public string IdMame { get; set; }
        public string IdOceta { get; set; }
        public int SteviloSorojencev { get; set; }
        public string Stanje { get; set; }
        public string Opombe { get; set; }
        public int SteviloKotitev { get; set; }
        public int PovprecjeJagenjckov { get; set; }
        public ICollection<Kotitev> SeznamKotitev { get; set; }

    }
}