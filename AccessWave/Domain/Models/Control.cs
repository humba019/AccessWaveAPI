using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Domain.Models
{
    public class Control
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string Entry { get; set; }
        public string Exit { get; set; }
    }
}
