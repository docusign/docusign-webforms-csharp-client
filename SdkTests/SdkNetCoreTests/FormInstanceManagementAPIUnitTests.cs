using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using DocuSign.WebForms.Api;
using DocuSign.WebForms.Client;
using DocuSign.WebForms.Model;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SdkNetCoreTests.Helpers;

namespace SdkNetCoreTests
{
    [TestClass]
    public class FormInstanceManagementAPIUnitTests
    {
        private static TestConfig _testConfig;
        private static FormInstanceManagementApi _mgmtInstanceApi;
        private static FormManagementApi _mgmtApi;
        private static string _formId;
        private static string _webFormInstanceId;
        private const string signerEmail = "customer@domain.com";
        private const string clientUserEmail = "customer_id@domain.com";

        [ClassInitialize()]
        public static void TestInitialize(TestContext ctx)
        {
            _testConfig = TestUtils.GetTestConfig();
            _mgmtApi = new FormManagementApi(_testConfig.ApiClient);
            _mgmtInstanceApi = new FormInstanceManagementApi(_testConfig.ApiClient);
            FillDependencies();
        }

        #region private methods
        private static void FillDependencies()
        {
            //Get Form ID
            var webforms = _mgmtApi.ListForms(_testConfig.AccountId);
            var publishedWebForms = webforms.Items.Where(x => x.IsPublished == true);
            if (publishedWebForms.Count() >= 1)
            {
                _formId = publishedWebForms.OrderBy(_ => _.FormProperties.Name).FirstOrDefault().Id;
            }

            //Get Instance ID
            var webformInstance = CreateWebFormInstance();
            _webFormInstanceId = webformInstance.Id;
        }

        private static WebFormInstance CreateWebFormInstance()
        {
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            WebFormValues values = new WebFormValues
            {
                { "Signer_name", "Hello" },
                { "Signer_email", signerEmail },
                { "T1", "Customer" }
            };

            List<string> tags = new List<string>{ "loan_application", "finance_dept" };

            CreateInstanceRequestBody requestBody = new CreateInstanceRequestBody()
            {
                FormValues = values,
                ClientUserId = clientUserEmail,
                AuthenticationInstant = "02/02/2023",
                AuthenticationMethod = AuthenticationMethod.Biometric,
                AssertionId = "client-1",
                SecurityDomain = "domain.com",
                ReturnUrl = "http://www.google.com",
                ExpirationOffset = 120,
                Tags = tags
            };

            var webFormInstance = _mgmtInstanceApi.CreateInstance(accountId, formId, requestBody);
            return webFormInstance;
        }
        #endregion       

        #region List Form Instances API With HttpInfo - GET

        [TestMethod]
        public void ListInstancesWithHttpInfo_ShouldReturnInstances_WithValidAccountId_FormId()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;

            //Act
            var apiResponse = _mgmtInstanceApi.ListInstancesWithHttpInfo(accountId, formId);

            //Assert
            Assert.IsNotNull(apiResponse.Data, "The webFormInstances should not be null.");
            Assert.IsTrue(apiResponse.Data.Items.Count > 0, "The list of instances should not be empty.");
        }        

        #endregion        

        #region List Form Instances API With HttpInfo Async - GET

        [TestMethod]
        public async Task ListInstancesAsyncWithHttpInfo_ShouldReturnInstances_WithValidAccountId_FormId()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;

            //Act
            var apiResponse = await _mgmtInstanceApi.ListInstancesAsyncWithHttpInfo(accountId, formId);

            //Assert
            Assert.IsNotNull(apiResponse.Data, "The webFormInstances should not be null.");
            Assert.IsTrue(apiResponse.Data.Items.Count > 0, "The list of instances should not be empty.");
        }       

        #endregion       

        #region Get Form Instance API With HttpInfo - GET
        [TestMethod]
        public void GerFormInstanceWithHttpInfo_ShouldReturnFormInstance_WithValidRequestParams()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            string instanceId = _webFormInstanceId;

            var apiResponse = _mgmtInstanceApi.GetInstanceWithHttpInfo(accountId, formId, instanceId);

            Assert.IsNotNull(apiResponse.Data);
            Assert.AreEqual(formId, apiResponse.Data.FormId);
            Assert.AreEqual(accountId, apiResponse.Data.AccountId);
        }

        [TestMethod]
        public void GerFormInstanceWithHttpInfo_ShouldReturnBadRequest_WithAccountIdAsNull()
        {
            //Arrange
            string accountId = null;
            string formId = _formId;
            string instanceId = _webFormInstanceId;

            try
            {
                var webFormInstance = _mgmtInstanceApi.GetInstanceWithHttpInfo(accountId, formId, instanceId);
                Assert.Fail("Exception should be thrown when Account Id is null");
            }
            catch (ApiException exception)
            {
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        [TestMethod]
        public void GerFormInstanceWithHttpInfo_ShouldReturnBadRequest_WithFormIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = null;
            string instanceId = _webFormInstanceId;

            try
            {
                var webFormInstance = _mgmtInstanceApi.GetInstanceWithHttpInfo(accountId, formId, instanceId);
                Assert.Fail("Exception should be thrown when Account Id is null");
            }
            catch (ApiException exception)
            {
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        [TestMethod]
        public void GerFormInstanceWithHttpInfo_ShouldReturnBadRequest_WithInstanceIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            string instanceId = null;

            try
            {
                var webFormInstance = _mgmtInstanceApi.GetInstanceWithHttpInfo(accountId, formId, instanceId);
                Assert.Fail("Exception should be thrown when Account Id is null");
            }
            catch (ApiException exception)
            {
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }
        #endregion

        #region Get Form Instance API With HttpInfo Async - GET
        [TestMethod]
        public async Task GerFormInstanceWithHttpInfoAsync_ShouldReturnFormInstance_WithValidRequestParams()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            string instanceId = _webFormInstanceId;

            var apiResponse = await _mgmtInstanceApi.GetInstanceAsyncWithHttpInfo(accountId, formId, instanceId);

            Assert.IsNotNull(apiResponse.Data);
            Assert.AreEqual(formId, apiResponse.Data.FormId);
            Assert.AreEqual(accountId, apiResponse.Data.AccountId);
        }

        [TestMethod]
        public async Task GerFormInstanceWithHttpInfoAsync_ShouldReturnBadRequest_WithAccountIdAsNull()
        {
            //Arrange
            string accountId = null;
            string formId = _formId;
            string instanceId = _webFormInstanceId;

            try
            {
                var webFormInstance = await _mgmtInstanceApi.GetInstanceAsyncWithHttpInfo(accountId, formId, instanceId);
                Assert.Fail("Exception should be thrown when Account Id is null");
            }
            catch (ApiException exception)
            {
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        [TestMethod]
        public async Task GerFormInstanceWithHttpInfoAsync_ShouldReturnBadRequest_WithFormIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = null;
            string instanceId = _webFormInstanceId;

            try
            {
                var webFormInstance = await _mgmtInstanceApi.GetInstanceAsyncWithHttpInfo(accountId, formId, instanceId);
                Assert.Fail("Exception should be thrown when Account Id is null");
            }
            catch (ApiException exception)
            {
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        [TestMethod]
        public async Task GerFormInstanceWithHttpInfoAsync_ShouldReturnBadRequest_WithInstanceIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            string instanceId = null;

            try
            {
                var webFormInstance = await _mgmtInstanceApi.GetInstanceAsyncWithHttpInfo(accountId, formId, instanceId);
                Assert.Fail("Exception should be thrown when Account Id is null");
            }
            catch (ApiException exception)
            {
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }
        #endregion       

        #region Create Form Instance API With HttpInfo - POST

        [TestMethod]
        public void CreateInstanceWithHttpInfo_ShouldReturnCreatedWebformInstance_WithValidFormId_AccountId()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            WebFormValues values = new WebFormValues
            {
                { "Signer_name", "Hello" },
                { "Signer_email", signerEmail },
                { "T1", "Customer" }
            };
            List<string> tags = new Tags { "loan_application", "finance_dept" };

            CreateInstanceRequestBody requestBody = new CreateInstanceRequestBody()
            {
                FormValues = values,
                ClientUserId = clientUserEmail,
                AuthenticationInstant = "02/02/2023",
                AuthenticationMethod = AuthenticationMethod.Biometric,
                AssertionId = "client-1",
                SecurityDomain = "domain.com",
                ReturnUrl = "http://www.google.com",
                ExpirationOffset = 120,
                Tags = tags
            };

            //Act
            var apiResponse = _mgmtInstanceApi.CreateInstanceWithHttpInfo(accountId, formId, requestBody);

            //Assert
            Assert.IsTrue(apiResponse.StatusCode == 200);
            Assert.AreEqual(requestBody.ClientUserId, apiResponse.Data.ClientUserId);
            Assert.AreEqual(requestBody.Tags.Count, apiResponse.Data.Tags.Count);
        }

        [TestMethod]
        public void CreateInstanceWithHttpInfo_ShouldReturnBadRequest_WithFormIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = null;
            WebFormValues values = new WebFormValues
            {
                { "Signer_name", "Hello" },
                { "Signer_email", signerEmail },  
                { "T1", "Customer" }
            };
            List<string> tags = new Tags { "loan_application", "finance_dept" };

            CreateInstanceRequestBody requestBody = new CreateInstanceRequestBody()
            {
                FormValues = values,
                ClientUserId = clientUserEmail,
                AuthenticationInstant = "02/02/2023",
                AuthenticationMethod = AuthenticationMethod.Biometric,
                AssertionId = "client-1",
                SecurityDomain = "domain.com",
                ReturnUrl = "http://www.google.com",
                ExpirationOffset = 120,
                Tags = tags
            };


            try
            {
                //Act
                var apiResponse = _mgmtInstanceApi.CreateInstanceWithHttpInfo(accountId, formId, requestBody);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        [TestMethod]
        public void CreateInstanceWithHttpInfo_ShouldReturnBadRequest_WithAccountIdAsNull()
        {
            //Arrange
            string accountId = null;
            string formId = _formId;
            WebFormValues values = new WebFormValues
            {
                { "Signer_name", "Hello" },
                { "Signer_email", signerEmail },
                { "T1", "Customer" }
            };
            List<string> tags = new List<string> { "loan_application", "finance_dept" }; ;

            CreateInstanceRequestBody requestBody = new CreateInstanceRequestBody()
            {
                FormValues = values,
                ClientUserId = clientUserEmail,
                AuthenticationInstant = "02/02/2023",
                AuthenticationMethod = AuthenticationMethod.Biometric,
                AssertionId = "client-1",
                SecurityDomain = "domain.com",
                ReturnUrl = "http://www.google.com",
                ExpirationOffset = 120,
                Tags = tags
            };


            try
            {
                //Act
                var apiResponse = _mgmtInstanceApi.CreateInstanceWithHttpInfo(accountId, formId, requestBody);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        [TestMethod]
        public void CreateInstanceWithHttpInfo_ShouldReturnBadRequest_WithRequestObjectAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;

            CreateInstanceRequestBody requestBody = null;

            try
            {
                //Act
                var apiResponse = _mgmtInstanceApi.CreateInstanceWithHttpInfo(accountId, formId, requestBody);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        #endregion

        #region Create Form Instance API With HttpInfo Async - POST

        [TestMethod]
        public async Task CreateInstanceWithHttpInfoAsync_ShouldReturnCreatedWebformInstance_WithValidFormId_AccountId()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            WebFormValues values = new WebFormValues
            {
                { "Signer_name", "Hello" },
                { "Signer_email", signerEmail },
                { "T1", "Customer" }
            };
            List<string> tags = new List<string> { "loan_application", "finance_dept" };

            CreateInstanceRequestBody requestBody = new CreateInstanceRequestBody()
            {
                FormValues = values,
                ClientUserId = clientUserEmail,
                AuthenticationInstant = "02/02/2023",
                AuthenticationMethod = AuthenticationMethod.Biometric,
                AssertionId = "client-1",
                SecurityDomain = "domain.com",
                ReturnUrl = "http://www.google.com",
                ExpirationOffset = 120,
                Tags = tags
            };

            //Act
            var apiResponse = await _mgmtInstanceApi.CreateInstanceAsyncWithHttpInfo(accountId, formId, requestBody);

            //Assert
            Assert.IsTrue(apiResponse.StatusCode == 200);
            Assert.AreEqual(requestBody.ClientUserId, apiResponse.Data.ClientUserId);
            Assert.AreEqual(requestBody.Tags.Count(), apiResponse.Data.Tags.Count());
        }

        [TestMethod]
        public async Task CreateInstanceWithHttpInfoAsync_ShouldReturnBadRequest_WithFormIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = null;
            WebFormValues values = new WebFormValues
            {
                { "Signer_name", "Hello" },
                { "Signer_email", signerEmail },
                { "T1", "Customer" }
            };
            List<string> tags = new List<string> { "loan_application", "finance_dept" };

            CreateInstanceRequestBody requestBody = new CreateInstanceRequestBody()
            {
                FormValues = values,
                ClientUserId = clientUserEmail,
                AuthenticationInstant = "02/02/2023",
                AuthenticationMethod = AuthenticationMethod.Biometric,
                AssertionId = "client-1",
                SecurityDomain = "domain.com",
                ReturnUrl = "http://www.google.com",
                ExpirationOffset = 120,
                Tags = tags
            };


            try
            {
                //Act
                var apiResponse = await _mgmtInstanceApi.CreateInstanceAsyncWithHttpInfo(accountId, formId, requestBody);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        [TestMethod]
        public async Task CreateInstanceWithHttpInfoAsync_ShouldReturnBadRequest_WithAccountIdAsNull()
        {
            //Arrange
            string accountId = null;
            string formId = _formId;
            WebFormValues values = new WebFormValues
            {
                { "Signer_name", "Hello" },
                { "Signer_email", signerEmail },
                { "T1", "Customer" }
            };
            List<string> tags = new List<string> { "loan_application", "finance_dept" };

            CreateInstanceRequestBody requestBody = new CreateInstanceRequestBody()
            {
                FormValues = values,
                ClientUserId = clientUserEmail,
                AuthenticationInstant = "02/02/2023",
                AuthenticationMethod = AuthenticationMethod.Biometric,
                AssertionId = "client-1",
                SecurityDomain = "domain.com",
                ReturnUrl = "http://www.google.com",
                ExpirationOffset = 120,
                Tags = tags
            };


            try
            {
                //Act
                var apiResponse = await _mgmtInstanceApi.CreateInstanceAsyncWithHttpInfo(accountId, formId, requestBody);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        [TestMethod]
        public async Task CreateInstanceWithHttpInfoAsync_ShouldReturnBadRequest_WithRequestObjectAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;

            CreateInstanceRequestBody requestBody = null;

            try
            {
                //Act
                var apiResponse = await _mgmtInstanceApi.CreateInstanceAsyncWithHttpInfo(accountId, formId, requestBody);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        #endregion               

        #region Refresh Instance Token API With HttpInfo - POST
        [TestMethod]
        public void RefreshInstanceTokenWithHttpInfo_ShouldReturnWebFormInstanceOfNewToken_WithValidRequestParams()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            var existingWebFormInstance = CreateWebFormInstance();
            string instanceId = existingWebFormInstance.Id;

            //Act
            var apiResponse = _mgmtInstanceApi.RefreshTokenWithHttpInfo(accountId, formId, instanceId);

            //Assert
            Assert.IsTrue(apiResponse.StatusCode == (int)HttpStatusCode.OK);
            Assert.IsTrue(!string.IsNullOrEmpty(apiResponse.Data.InstanceToken));
            Assert.AreNotEqual(existingWebFormInstance.InstanceToken, apiResponse.Data.InstanceToken);

        }

        [TestMethod]
        public void RefreshInstanceTokenWithHttpInfo_ShouldReturnBadRequest_WithAccountIdAsNull()
        {
            //Arrange
            string accountId = null;
            string formId = _formId;
            string instanceId = _webFormInstanceId;

            try
            {
                //Act
                var apiResponse = _mgmtInstanceApi.RefreshTokenWithHttpInfo(accountId, formId, instanceId);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }

        }

        [TestMethod]
        public void RefreshInstanceTokenWithHttpInfo_ShouldReturnBadRequest_WithFormIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = null;
            string instanceId = _webFormInstanceId;

            try
            {
                //Act
                var apiResponse = _mgmtInstanceApi.RefreshTokenWithHttpInfo(accountId, formId, instanceId);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }

        }

        [TestMethod]
        public void RefreshInstanceTokenWithHttpInfo_ShouldReturnBadRequest_WithInstanceIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            string instanceId = null;

            try
            {
                //Act
                var apiResponse = _mgmtInstanceApi.RefreshTokenWithHttpInfo(accountId, formId, instanceId);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }

        }
        #endregion       

        #region Refresh Instance Token API With HttpInfo Asyc - POST
        [TestMethod]
        public async Task RefreshInstanceTokenWithHttpInfoAsync_ShouldReturnWebFormInstanceOfNewToken_WithValidRequestParams()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            var existingWebFormInstance = CreateWebFormInstance();
            string instanceId = existingWebFormInstance.Id;

            //Act
            var apiResponse = await _mgmtInstanceApi.RefreshTokenAsyncWithHttpInfo(accountId, formId, instanceId);

            //Assert
            Assert.IsTrue(apiResponse.StatusCode == (int)HttpStatusCode.OK);
            Assert.IsTrue(!string.IsNullOrEmpty(apiResponse.Data.InstanceToken));
            Assert.AreNotEqual(existingWebFormInstance.InstanceToken, apiResponse.Data.InstanceToken);

        }

        [TestMethod]
        public async Task RefreshInstanceTokenWithHttpInfoAsync_ShouldReturnBadRequest_WithAccountIdAsNull()
        {
            //Arrange
            string accountId = null;
            string formId = _formId;
            string instanceId = _webFormInstanceId;

            try
            {
                //Act
                var apiResponse = await _mgmtInstanceApi.RefreshTokenAsyncWithHttpInfo(accountId, formId, instanceId);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }

        }

        [TestMethod]
        public async Task RefreshInstanceTokenWithHttpInfoAsync_ShouldReturnBadRequest_WithFormIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = null;
            string instanceId = _webFormInstanceId;

            try
            {
                //Act
                var apiResponse = await _mgmtInstanceApi.RefreshTokenAsyncWithHttpInfo(accountId, formId, instanceId);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }

        }

        [TestMethod]
        public async Task RefreshInstanceTokenWithHttpInfoAsync_ShouldReturnBadRequest_WithInstanceIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            string instanceId = null;

            try
            {
                //Act
                var apiResponse = await _mgmtInstanceApi.RefreshTokenAsyncWithHttpInfo(accountId, formId, instanceId);
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }

        }
        #endregion
    }
}
