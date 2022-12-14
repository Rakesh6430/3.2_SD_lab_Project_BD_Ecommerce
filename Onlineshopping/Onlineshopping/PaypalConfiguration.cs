using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Onlineshopping
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;

        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AcIz7O03LtjDpVP9RTSMBBc3YQfJ-JX1Maqj8-v6cicS-Y4I3QEPgv3DmYJ140D_KvMUed81zpSlRwar";
            clientSecret = "EMM2kbMJnEdAISyD4Ufx0D4YLyYb3SBYwInEO4e-YRBs2MI0qyV6S3g3xI8kLobf-BYGJBZEefCaTEJB";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }

    }
}