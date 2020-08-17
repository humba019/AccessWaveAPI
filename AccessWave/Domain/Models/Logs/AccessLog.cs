using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Domain.Models
{
    public class AccessLog
    {
        public int Code { get; set; }
        public int CodeAccess { get; set; }
        public int CodeDevice { get; set; }
        public string LastAccess { get; set; }

    }
}
