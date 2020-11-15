using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{   
    public class Jagenjcek
        {
        [Key]
        [Display(Name = "ID jagenjčka")] 
        public int IdJagenjcka { get; set; }
        
        public Kotitev IdKotitve { get; set; }
        [Display(Name = "Spol")] 
        public string spol { get; set; }

    }
}