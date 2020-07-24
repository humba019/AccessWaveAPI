using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Domain.Models
{
    public class Access
    {
        public int Code { get; set; }
        public string Entry { get; set; }
        public string Exit { get; set; }
        public int CodeStudent { get; set; }
        public int CodeDevice { get; set; }
        public Device Device { get; set; }
        public int CodeControl { get; set; }
        public Control Control { get; set; }

    }
}
