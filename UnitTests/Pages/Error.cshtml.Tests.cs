using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;
using System.Diagnostics;

namespace UnitTests.Pages
{
    ///<summary>
    ///The purpose of this class is to run a Error test
    ///on the Error method because we want to have a 100%
    ///coverage for our unit tests.
    ///</summary>
    public class ErrorTests
    {
        #region TestSetup
        public static ErrorModel pageModel;

        /// <summary>
        /// Initializes the test for setup using the MockLoggerDirect.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            //MockLoggerDirect is set to the error model of ILogger mock.
            var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();

            ///Page model is instantiated to a new error model.
            pageModel = new ErrorModel(MockLoggerDirect)
            {
                ///PageContext is set to test helper page context.
                PageContext = TestHelper.PageContext,
                ///Tempory helper is set.
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        ///Runs the unit test.
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            /// Arrange
            
            Activity activity = new Activity("activity");
            activity.Start();

            /// Act
            pageModel.OnGet();

            /// Reset

            /// Assert
            /// Validates to see if the input data are valid.
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(activity.Id, pageModel.RequestId);
            Assert.AreEqual(true, pageModel.ShowRequestId);

        }

        #endregion OnGet
        #region OnGet
        [Test]
        ///Runs the unit test.
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            /// Arrange

            /// Act
            pageModel.OnGet();
            /// Reset
            /// Assert
            /// Validates to see if the input data are valid.
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("trace", pageModel.RequestId);
            Assert.AreEqual(true, pageModel.ShowRequestId);

        }

        #endregion OnGet
    }
}


