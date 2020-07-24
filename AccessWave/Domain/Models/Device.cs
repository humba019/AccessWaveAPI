using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Domain.Models
{
    public class Device
    {
        public int Code { get; set; }
        public string FirstBlock { get; set; }
        public string SecondBlock { get; set; }
        public string ThirdBlock { get; set; }
        public string FourthBlock { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }

    }
}
