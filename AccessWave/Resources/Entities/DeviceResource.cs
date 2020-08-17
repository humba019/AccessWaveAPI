using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources.Entities
{
    public class DeviceResource
    {
        public int Code { get; set; }
        public string FirstBlock { get; set; }
        public string SecondBlock { get; set; }
        public string ThirdBlock { get; set; }
        public string FourthBlock { get; set; }
        public UserResource User { get; set; }
    }
}
