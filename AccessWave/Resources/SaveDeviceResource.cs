using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources
{
    public class SaveDeviceResource
    {
        [Required]
        public string FirstBlock { get; set; }
        [Required]
        public string SecondBlock { get; set; }
        [Required]
        public string ThirdBlock { get; set; }
        [Required]
        public string FourthBlock { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
