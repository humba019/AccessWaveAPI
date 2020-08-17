using AccessWave.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources.Entities
{
    public class AccessLogResource
    {
        public int Code { get; set; }
        public string LastAccess { get; set; }
    }
}
