using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;
using System.Diagnostics;

namespace UnitTests.Pages
{
    //<summary>
    //The purpose of this class is to run a Error test
    //on the Error method because we want to have a 100%
    //coverage for our unit tests.
    //</summary>
    public class ErrorTests
    {
        #region TestSetup
        public static ErrorModel pageModel;

        //Initializes the test for setup using the MockLoggerDirect.
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();

            pageModel = new ErrorModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        //Runs the unit test.
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange
            
            Activity activity = new Activity("activity");
            activity.Start();

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(activity.Id, pageModel.RequestId);
            Assert.AreEqual(true, pageModel.ShowRequestId);

        }

        #endregion OnGet
        #region OnGet
        [Test]
        //Runs the unit test.
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            // Arrange


            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("trace", pageModel.RequestId);
            Assert.AreEqual(true, pageModel.ShowRequestId);

        }

        #endregion OnGet
    }
}


