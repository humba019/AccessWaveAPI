using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources.Entities
{
    public class AccessResource
    {
        public int Code { get; set; }
        public string Entry { get; set; }
        public string Exit { get; set; }
        public int CodeStudent { get; set; }
        public DeviceResource Device { get; set; }
        public ControlResource Control { get; set; }
    }
}
