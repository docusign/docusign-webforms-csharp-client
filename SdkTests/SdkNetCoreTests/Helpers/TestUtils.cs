using System.Collections.Generic;

using DocuSign.WebForms.Client;
using DocuSign.WebForms.Client.Auth;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SdkNetCoreTests.Helpers
{
    public static class TestUtils
    {
        public static TestConfig GetTestConfig()
        {
            TestConfig config = new TestConfig();
            config.ApiClient = new DocuSignClient(config.Host);
            byte[] privateKeyStream = config.PrivateKey;
            var scopes = new List<string> { OAuth.Scope_SIGNATURE, OAuth.Scope_IMPERSONATION, "webforms_read", "webforms_instance_read", "webforms_instance_write" };

            OAuth.OAuthToken tokenInfo = config.ApiClient.RequestJWTUserToken(
                  config.IntegratorKey,
                config.UserId,
                config.OAuthBasePath,
                privateKeyStream,
                config.ExpiresInHours,
                scopes);

            OAuth.UserInfo userInfo = config.ApiClient.GetUserInfo(tokenInfo.access_token);

            Assert.IsNotNull(userInfo?.Accounts);

            foreach (OAuth.UserInfo.Account item in userInfo.Accounts)
            {
                if (item.IsDefault == "true")
                {
                    config.AccountId = item.AccountId;
                    break;
                }
            }

            return config;
        }
    }
}
