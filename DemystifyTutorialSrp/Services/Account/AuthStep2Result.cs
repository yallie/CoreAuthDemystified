using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemystifyTutorialSrp.Services.Account
{
    public class AuthStep2Result
    {
        /// <summary>
        /// Error code (0 = Ok).
        /// </summary>
        public int Error { get; set; }

        /// <summary>
        /// Unique server-side string from Step1.
        /// </summary>
        public string Uniq2 { get; set; }

        /// <summary>
        /// m2 hexadecimal.
        /// </summary>
        public string m2Hex { get; set; }

        /// <summary>
        /// Redirect to page.
        /// </summary>
        public string Redirect { get; set; }
    }
}
