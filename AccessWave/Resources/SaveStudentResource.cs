using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources
{
    public class SaveStudentResource
    {
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        public int CodePeriod { get; set; }
        [Required]
        public int CodeEducation { get; set; }
    }
}
