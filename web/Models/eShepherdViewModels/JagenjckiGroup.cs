using System;
using System.ComponentModel.DataAnnotations;

namespace web.Models.eShepherdViewModels
{
    public class JagenjckiGroup
    {
        [DataType(DataType.Date)]
        public String KotitevID { get; set; }

        public int JagenjckiCount { get; set; }
    }
}