using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources
{
    public class SaveAccessResource
    {
        [Required]
        public string Entry { get; set; }
        [Required]
        public string Exit { get; set; }
        [Required]
        public int CodeEmployee { get; set; }
        [Required]
        public int CodeStudent { get; set; }
        [Required]
        public int CodeControl { get; set; }
    }
}
