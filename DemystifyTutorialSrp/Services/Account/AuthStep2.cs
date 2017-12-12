using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemystifyTutorialSrp.Services.Account
{
    public class AuthStep2
    {
        /// <summary>
        /// Hashed user name.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Unique server-side string taken from Step1 auth result.
        /// </summary>
        public string Uniq1 { get; set; }

        /// <summary>
        /// m1 hexadecimal, computed at the client side.
        /// </summary>
        public string m1Hex { get; set; }
    }
}
