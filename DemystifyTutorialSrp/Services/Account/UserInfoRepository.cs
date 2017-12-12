using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemystifyTutorialSrp.Services.Account
{
    public static class UserInfoRepository
    {
        public static ConcurrentDictionary<string, UserInfo> UserInfos { get; } =
            new ConcurrentDictionary<string, UserInfo>();

        public static void AddAccount(UserInfo userInfo)
        {
            UserInfos[userInfo.UserHex] = userInfo;
        }

        public static int AuthStep1(string user, out string sHex, out string vHex, out string userName)
        {
            if (UserInfos.TryGetValue(user, out var result))
            {
                sHex = result.SHex;
                vHex = result.VHex;
                userName = result.UserName;
                return 0;
            }

            sHex = null;
            vHex = null;
            userName = null;
            return 1;
        }
    }
}
