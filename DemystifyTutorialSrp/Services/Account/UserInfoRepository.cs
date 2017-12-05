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
    }
}
