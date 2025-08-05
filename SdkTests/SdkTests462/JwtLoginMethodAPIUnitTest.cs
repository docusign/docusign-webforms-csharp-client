using DocuSign.WebForms.Client;
using DocuSign.WebForms.Client.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SdkNetCoreTests
{
    [TestClass]
    public class JwtLoginMethodAPIUnitTest
    {
        [TestMethod]
        public void RequestJWTUserToken_CorrectInputParameters_ReturnsOAuthToken()
        {
            TestConfig testConfig = new TestConfig();
            testConfig.ApiClient = new DocuSignClient(testConfig.Host);

            Assert.IsNotNull(testConfig?.PrivateKey);

            byte[] privateKeyStream = testConfig.PrivateKey;

            var scopes = new List<string> { OAuth.Scope_IMPERSONATION, OAuth.Scope_SIGNATURE, "webforms_read", "webforms_instance_read", "webforms_instance_write" };

            OAuth.OAuthToken tokenInfo = testConfig.ApiClient.RequestJWTUserToken(
                testConfig.IntegratorKey,
                testConfig.UserId,
                testConfig.OAuthBasePath,
                privateKeyStream,
                testConfig.ExpiresInHours,
                scopes);

            Assert.IsNotNull(tokenInfo.access_token);
            
            OAuth.UserInfo userInfo = testConfig.ApiClient.GetUserInfo(tokenInfo.access_token);

            Assert.IsNotNull(userInfo?.Accounts);

            foreach (OAuth.UserInfo.Account item in userInfo.Accounts)
            {
                if (item.IsDefault == "true")
                {
                    testConfig.AccountId = item.AccountId;
                    break;
                }
            }

            Assert.IsNotNull(testConfig?.AccountId);
        }
    }
}
