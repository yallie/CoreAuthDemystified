using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemystifyTutorialSrp.Services.Account
{
    public class UserInfo
    {
        /// <summary>
        /// Hashed user name.
        /// </summary>
        public string UserHex { get; set; }

        /// <summary>
        /// Salt.
        /// </summary>
        public string SHex { get; set; }

        /// <summary>
        /// Password validator.
        /// </summary>
        public string VHex { get; set; }
    }
}
