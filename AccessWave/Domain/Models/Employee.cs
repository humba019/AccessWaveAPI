using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Domain.Models
{
    public class Employee
    {
        public int Code { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
        public int CodePeriod { get; set; }
        public Period Period { get; set; }
    }
}
