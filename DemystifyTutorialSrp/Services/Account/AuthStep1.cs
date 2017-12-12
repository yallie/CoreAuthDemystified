using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemystifyTutorialSrp.Services.Account
{
    public class AuthStep1
    {
        /// <summary>
        /// Hashed user name.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// A hexadecimal.
        /// </summary>
        public string AHex { get; set; }
    }
}
