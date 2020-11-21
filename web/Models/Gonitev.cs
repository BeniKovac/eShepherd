using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Gonitev
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GonitevID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum gonitve")] 
        public DateTime DatumGonitve { get; set; }

        public string OvcaID { get; set; }
        public Ovca Ovca { get; set; }

        public string OvenID { get; set; }
        public Oven Oven { get; set; }
        
        // pristej 150 dni do datuma kotitve
        [Display(Name = "Predviden datum kotitve")] 
        public DateTime PredvidenaKotitev { get; set; }
        
        public string? Opombe { get; set; }

    }
}