﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemystifyTutorialSrp.Services.Account
{
    public class AuthStep1Result
    {
        /// <summary>
        /// Error code (0 = Ok).
        /// </summary>
        public int Error { get; set; }

        /// <summary>
        /// Unique server-side string from Step1.
        /// </summary>
        public string Uniq1 { get; set; }

        /// <summary>
        /// s hexadecimal (Salt).
        /// </summary>
        public string sHex { get; set; }

        /// <summary>
        /// B hexadecimal.
        /// </summary>
        public string BHex { get; set; }

        /// <summary>
        /// u hexadecimal.
        /// </summary>
        public string uHex { get; set; }
    }
}
