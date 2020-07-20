using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources.Entities
{
    public class EmployeeResource
    {
        public int Code { get; set; }
        public UserResource UserResource { get; set; }
        public PeriodResource PeriodResource { get; set; }
    }
}
