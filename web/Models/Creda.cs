using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Creda
    {
        
        [Key]
        [Display(Name = "ID črede")] 
        public int CredeID { get; set; }

        [Display(Name = "Število ovac v čredi")] 
        public int SteviloOvc { get; set; }
        public string? Opombe { get; set; }

        
        //[Display(Name = "ID ovna")] 
        //public string OvenID { get; set; }
        //public Oven oven { get; set; }

        public ICollection<Ovca> SeznamOvac { get; set; }
        
        public ICollection<Jagenjcek> SeznamJagenjckov { get; set; }


    }
}