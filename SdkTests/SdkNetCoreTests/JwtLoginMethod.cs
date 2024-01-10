using DocuSign.WebForms.Client;
using DocuSign.WebForms.Client.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SdkNetCoreTests
{
    [TestClass]
    public class JwtLoginMethod
    {
        [TestMethod]
        public static void RequestJWTUserToken_CorrectInputParameters_ReturnsOAuthToken(ref TestConfig testConfig)
        {
            testConfig.ApiClient = new DocuSignClient(testConfig.Host);

            Assert.IsNotNull(testConfig?.PrivateKey);

            byte[] privateKeyStream = testConfig.PrivateKey;

            var scopes = new List<string> { OAuth.Scope_SIGNATURE, OAuth.Scope_IMPERSONATION};

            OAuth.OAuthToken tokenInfo = testConfig.ApiClient.RequestJWTUserToken(
                testConfig.IntegratorKey,
                testConfig.UserId,
                testConfig.OAuthBasePath,
                privateKeyStream,
                testConfig.ExpiresInHours,
                scopes);

            tokenInfo.access_token = "";

            if (!testConfig.ApiClient.Configuration.DefaultHeader.ContainsKey("Authorization"))
            {
                testConfig.ApiClient.Configuration.DefaultHeader.Add("Authorization", string.Format("{0} {1}", tokenInfo.token_type, tokenInfo.access_token));
            }
            else
            {
                testConfig.ApiClient.Configuration.DefaultHeader["Authorization"] = string.Format("{0} {1}", tokenInfo.token_type, tokenInfo.access_token);
            }

            Assert.IsNotNull(tokenInfo.access_token);

            //using (MemoryStream ms = new MemoryStream(privateKeyStream))
            //{
            //    OAuth.OAuthToken tokenInfoFromStream = testConfig.ApiClient.RequestJWTUserToken(
            //        testConfig.IntegratorKey,
            //        testConfig.UserId,
            //        testConfig.OAuthBasePath,
            //        ms,
            //        testConfig.ExpiresInHours,
            //        scopes);

            //    Assert.IsNotNull(tokenInfoFromStream.access_token);
            //}

            //OAuth.UserInfo userInfo = testConfig.ApiClient.GetUserInfo(tokenInfo.access_token);

            //Assert.IsNotNull(userInfo?.Accounts);

            //foreach (OAuth.UserInfo.Account item in userInfo.Accounts)
            //{
            //    if (item.IsDefault == "true")
            //    {
            //        testConfig.AccountId = item.AccountId;
            //        testConfig.ApiClient.SetBasePath(item.BaseUri + "/restapi");
            //        break;
            //    }
            //}

            //Assert.IsNotNull(testConfig?.AccountId);
        }
    }
}
