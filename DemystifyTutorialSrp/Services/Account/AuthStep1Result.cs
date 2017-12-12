using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemystifyTutorialSrp.Services.Account
{
    public class AuthStep1Result
    {
        public int Error { get; set; }

        public string Uniq1 { get; set; }

        public string sHex { get; set; }

        public string BHex { get; set; }

        public string uHex { get; set; }
    }
}
