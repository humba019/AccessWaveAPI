using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources
{
    public class SaveControlResource
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public string Entry { get; set; }
        [Required]
        public string Exit { get; set; }
    }
}
