using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Gonitev
    {
        
        [Key]
        public int GonitevID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum gonitve")] 
        public DateTime DatumGonitve { get; set; }

        public Oven Oven { get; set; }
        
        public Ovca Ovca { get; set; }
        
        [Display(Name = "Predviden datum kotitve")] 
        public DateTime PredvidenaKotitev { get; set; }
        
        public string? Opombe { get; set; }

    }
}