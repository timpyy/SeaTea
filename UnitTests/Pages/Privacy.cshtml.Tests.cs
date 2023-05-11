using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Privacy
{
    //<summary>
    //The purpose of this class is to run a Privacy test
    //on the Privacy method because we want to have a 100%
    //coverage for our unit tests.
    //</summary>
    public class PrivacyTests
    {
        #region TestSetup
        public static PrivacyModel pageModel;

        //Initializes the test for setup using the MockLoggerDirect.
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<PrivacyModel>>();

            pageModel = new PrivacyModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        //Runs the unit test.
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion OnGet
    }
}
