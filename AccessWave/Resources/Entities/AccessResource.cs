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
        public EmployeeResource EmployeeResource { get; set; }
        public StudentResource StudentResource { get; set; }
        public ControlResource ControlResource { get; set; }
    }
}
