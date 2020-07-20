using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources.Entities
{
    public class StudentResource
    {
        public int Code { get; set; }
        public UserResource UserResource { get; set; }
        public PeriodResource PeriodResource { get; set; }
        public EducationResource EducationResource { get; set; }
    }
}
