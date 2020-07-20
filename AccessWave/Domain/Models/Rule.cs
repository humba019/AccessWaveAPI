using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Domain.Models
{
    public class Rule
    {
        public int Code { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
