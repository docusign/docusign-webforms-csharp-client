using DocuSign.WebForms.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SdkNetCoreTests
{
    [TestClass]
    public class FormManagementAPIUnitTests
    {
        private TestConfig _testConfig;
        private FormManagementApi _mgmtApi;

        [TestInitialize]
        public void TestInitialize()
        {
            _testConfig = new TestConfig();
            JwtLoginMethod.RequestJWTUserToken_CorrectInputParameters_ReturnsOAuthToken(ref _testConfig);
            _mgmtApi = new FormManagementApi(_testConfig.ApiClient);

        }

        [TestMethod]
        public void ListForms_ShouldReturnForms()
        {

            var forms = _mgmtApi.ListForms("3c9c0391-01ac-4a98-8fab-adb9d0e548d2");

            Assert.IsNotNull(forms, "The list of forms should not be null.");
            Assert.IsNotNull(forms.Items, "The list of forms should have an 'Items' property.");

            Assert.IsTrue(forms.Items.Any(), "The list of forms should not be empty.");

            //var frmApi = new FormInstanceManagementApi(_testConfig.ApiClient);

            //var formInstances = frmApi.ListInstances(Guid.Parse("3c9c0391-01ac-4a98-8fab-adb9d0e548d2"), forms.Items[0].Id);

            //var obj = new CreateInstanceRequestBody(new WebFormValues()
            //{
            //    { "Signer_name", "docusignsdktest"},
            //    { "Signer_email", "docusignsdktest@mailinator.com"},
            //    { "T1", "docusignsdktest@mailinator.com"},
            //}, "1234-5678-abcd-ijkl", ExpirationOffset: 3600);

            //var instance = frmApi.CreateInstance(Guid.Parse("3c9c0391-01ac-4a98-8fab-adb9d0e548d2"), forms.Items[0].Id, obj);

            //formInstances = frmApi.ListInstances(Guid.Parse("3c9c0391-01ac-4a98-8fab-adb9d0e548d2"), forms.Items[0].Id);
            //var formInstance = frmApi.GetInstance(Guid.Parse("3c9c0391-01ac-4a98-8fab-adb9d0e548d2"), forms.Items[0].Id, instance.Id);

        }
    }
}
