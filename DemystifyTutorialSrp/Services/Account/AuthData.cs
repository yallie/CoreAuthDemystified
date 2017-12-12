using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemystifyTutorialSrp.Services.Account
{
    public class AuthData
    {
		public string User;
		public string Uniq;
		public string sHex;
		public string vHex;
		public string AHex;
		public string bHex;
		public string BHex;
		public string uHex;

		public static List<AuthData> AuthDataList { get; } = new List<AuthData>();

		public static void Add(AuthData auth)
		{
			lock (AuthDataList)
			{
				AuthDataList.Add(auth);
			}
		}
    }
}
