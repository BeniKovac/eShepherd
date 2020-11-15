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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum Kotitve")] 
        public DateTime DatumKotitve { get; set; }
        public int SteviloMladih { get; set; }
        public Oven Oven { get; set; }
        public Ovca Ovca { get; set; }
        public int SteviloMrtvih { get; set; }
        public string Opombe { get; set; }

    }
}