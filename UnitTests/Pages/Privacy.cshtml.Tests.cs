using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Privacy
{
    ///<summary>
    ///The purpose of this class is to run a Privacy test
    ///on the Privacy method because we want to have a 100%
    ///coverage for our unit tests.
    ///</summary>
    public class PrivacyTests
    {
        #region TestSetup
        public static PrivacyModel pageModel;

        ///Initializes the test for setup using the MockLoggerDirect.
        [SetUp]
        public void TestInitialize()
        {
            // MocklOGGER is set to the of Mock of ILogger Privacy model.
            var MockLoggerDirect = Mock.Of<ILogger<PrivacyModel>>();

            // Initiates privcy model to use test helper.
            pageModel = new PrivacyModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        ///Runs a unit test on the return value for privacy on get function
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            // Validates to see if input data is valid.
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion OnGet
        
    }
}
