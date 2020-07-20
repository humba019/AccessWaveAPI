using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources
{
    public class SaveRuleResource
    {

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
