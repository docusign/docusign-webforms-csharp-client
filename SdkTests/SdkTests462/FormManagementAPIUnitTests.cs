using DocuSign.WebForms.Api;
using DocuSign.WebForms.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SdkNetCoreTests.Helpers;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static DocuSign.WebForms.Api.FormManagementApi;

namespace SdkNetCoreTests
{
    [TestClass]
    public class FormManagementAPIUnitTests
    {
        private static TestConfig _testConfig;
        private static FormManagementApi _mgmtApi;
        private static string _formId;

        [ClassInitialize()]
        public static void TestInitialize(TestContext ctx)
        {
            _testConfig = TestUtils.GetTestConfig();
            _mgmtApi = new FormManagementApi(_testConfig.ApiClient);
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
                _formId = publishedWebForms.First().Id;
            }
        }

        #endregion

        #region List Forms API With HttpInfo - GET
        [TestMethod]
        public void ListFormsWithHttpInfo_ShouldReturnForms_WithValidAccountId()
        {
            //Arrange
            string accountId = _testConfig.AccountId;

            //Act
            var apiResponse = _mgmtApi.ListFormsWithHttpInfo(accountId);

            //Assert
            Assert.IsNotNull(apiResponse.Data, "The list of forms should not be null.");
            Assert.IsTrue(apiResponse.Data.Items.Any(), "The list of forms should not be empty.");
        }

        [TestMethod]
        public void ListFormsWithHttpInfo_ShouldReturnBadRequest_WithAccountIdAsNull()
        {
            //Arrange
            string accountId = null;

            //Act
            try
            {
                var apiResponse = _mgmtApi.ListFormsWithHttpInfo(accountId);
                Assert.Fail("Exception should be thrown when accountId is null");
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }
        #endregion

        #region List Forms API With HttpInfo Async  - GET
        [TestMethod]
        public async Task ListFormsWithHttpInfoAsync_ShouldReturnForms_WithValidAccountId()
        {
            //Arrange
            string accountId = _testConfig.AccountId;

            //Act
            var apiResponse = await _mgmtApi.ListFormsAsyncWithHttpInfo(accountId);

            //Assert
            Assert.IsNotNull(apiResponse.Data, "The list of forms should not be null.");
            Assert.IsTrue(apiResponse.Data.Items.Any(), "The list of forms should not be empty.");
        }

        [TestMethod]
        public async Task ListFormsWithHttpInfoAsync_ShouldReturnBadRequest_WithAccountIdAsNull()
        {
            //Arrange
            string accountId = null;

            //Act
            try
            {
                var apiResponse = await _mgmtApi.ListFormsAsyncWithHttpInfo(accountId);
                Assert.Fail("Exception should be thrown when accountId is null");
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }
        #endregion       

        #region Get Form API With HttpInfo - GET
        [TestMethod]
        public void GetFormWithHttpInfo_ShouldReturnForm_WithValidAccountId_FormId()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            GetFormOptions options = new GetFormOptions() { state = "active" };

            //Act
            var apiResponse = _mgmtApi.GetFormWithHttpInfo(accountId, formId, options);

            //Assert
            Assert.IsNotNull(apiResponse.Data, "Form Object cannot be null");
            Assert.AreEqual(formId, apiResponse.Data.Id, "WebformId in request and response should match");
        }

        [TestMethod]
        public void GetFormWithHttpInfo_ShouldReturnBadRequest_WithFormIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = null;
            GetFormOptions options = new GetFormOptions() { state = "active" };

            try
            {
                //Act
                var apiResponse = _mgmtApi.GetFormWithHttpInfo(accountId, formId, options);
                Assert.Fail("Exception should be thrown when invalid form id is passed");
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        [TestMethod]
        public void GetFormWithHttpInfo_ShouldReturnBadRequest_WithAccountIdAsNull()
        {
            //Arrange
            string accountId = null;
            string formId = _formId;
            GetFormOptions options = new GetFormOptions() { state = "active" };

            try
            {
                //Act
                var apiResponse = _mgmtApi.GetFormWithHttpInfo(accountId, formId, options);
                Assert.Fail("Exception should be thrown when invalid account id is passed");
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        #endregion

        #region Get Form API With HttpInfo Async - GET
        [TestMethod]
        public async Task GetFormAsyncWithHttpInfo_ShouldReturnForm_WithValidAccountId_FormId()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = _formId;
            GetFormOptions options = new GetFormOptions() { state = "active" };

            //Act
            var apiResponse = await _mgmtApi.GetFormAsyncWithHttpInfo(accountId, formId, options);

            //Assert
            Assert.IsNotNull(apiResponse.Data, "Form Object cannot be null");
            Assert.AreEqual(formId, apiResponse.Data.Id, "WebformId in request and response should match");
        }

        [TestMethod]
        public async Task GetFormAsyncWithHttpInfo_ShouldReturnBadRequest_WithFormIdAsNull()
        {
            //Arrange
            string accountId = _testConfig.AccountId;
            string formId = null;
            GetFormOptions options = new GetFormOptions() { state = "active" };

            try
            {
                //Act
                var apiResponse = await _mgmtApi.GetFormAsyncWithHttpInfo(accountId, formId, options);
                Assert.Fail("Exception should be thrown when invalid form id is passed");
            }
            catch (ApiException exception)
            {
                //Assert
                Assert.AreEqual((int)HttpStatusCode.BadRequest, exception.ErrorCode);
            }
        }

        [TestMethod]
        public async Task GetFormAsyncWithHttpInfo_ShouldReturnBadRequest_WithAccountIdAsNull()
        {
            //Arrange
            string accountId = null;
            string formId = _formId;
            GetFormOptions options = new GetFormOptions() { state = "active" };

            try
            {
                //Act
                var apiResponse = await _mgmtApi.GetFormAsyncWithHttpInfo(accountId, formId, options);
                Assert.Fail("Exception should be thrown when invalid account id is passed");
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
