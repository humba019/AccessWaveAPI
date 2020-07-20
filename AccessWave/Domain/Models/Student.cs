using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Domain.Models
{
    public class Student
    {
        public int Code { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
        public int CodePeriod { get; set; }
        public Period Period { get; set; }
        public int CodeEducation { get; set; }
        public Education Education { get; set; }
    }
}
