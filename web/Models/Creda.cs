using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class Creda
    {
        
        [Key]
        public int CredeID { get; set; }
        public int SteviloOvc { get; set; }
        public string Opombe { get; set; }
    }
}