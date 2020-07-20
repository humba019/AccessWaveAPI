using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Domain.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string FullName { get; set; }
        public string LastAccess { get; set; }
        public int CodeRule { get; set; }
        public Rule Rule { get; set; }
    }
}
