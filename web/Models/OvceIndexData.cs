using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    public class OvceIndexData
    {
        public IEnumerable<Ovca> Ovce { get; set; }
        public IEnumerable<Kotitev> Kotitve { get; set; }


    }
}