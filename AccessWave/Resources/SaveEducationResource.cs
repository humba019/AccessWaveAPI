using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources
{
    public class SaveEducationResource
    {
        [Required]
        [MaxLength(60)]
        public string Level { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
