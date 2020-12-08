using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models.eShepherdViewModels
{
    public class KotitveIndexData
    {
        public PaginatedList<Kotitev> Kotitve { get; set; }
        public IEnumerable<Jagenjcek> Jagenjcki { get; set; }
    }
}