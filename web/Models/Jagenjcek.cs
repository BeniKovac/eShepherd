using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{   
    public class Jagenjcek
        {
        [Key]
        public int IdJagenjcka { get; set; }

        public Kotitev IdKotitve { get; set; }
        public string spol { get; set; }

    }
}