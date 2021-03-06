﻿using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources.Entities
{
    public class StudentResource
    {
        public int Code { get; set; }
        public UserResource User { get; set; }
        public PeriodResource Period { get; set; }
        public EducationResource Education { get; set; }
    }
}
