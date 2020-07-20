using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Resources.Entities
{
    public class UserResource
    {
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string FullName { get; set; }
        public string LastAccess { get; set; }
        public RuleResource RuleResource { get; set; }
    }
}
