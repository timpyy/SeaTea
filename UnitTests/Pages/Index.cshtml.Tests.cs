using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;
using System.Linq;

namespace UnitTests.Pages.Index
{
    ///<summary>
    ///The purpose of this class is to run a index test
    ///on the index method because we want to have a 100%
    ///coverage for our unit tests.
    ///</summary>
    public class IndexTests
    {
        #region TestSetup
        public static IndexModel pageModel;

        /// <summary>
        /// Initializes the test for setup using the MockLoggerDirect.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            //MockLoggerDirect is set to the error model of ILogger mock.
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            ///Page model is instantiated to a new error model.
            pageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        ///Runs the unit test.
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            /// Arrange

            /// Act
            pageModel.OnGet();

            /// Reset

            // Assert
            /// Validates to see if the input data are valid.
            Assert.AreEqual(true, pageModel.ModelState.IsValid);


        }

        #endregion OnGet
        #region OnGet
        /// <summary>
        /// Unit test for checking valid search string returns corresponding product
        /// </summary>
        [Test]
        public void OnGet_Should_Return_All_Products()
        {
            /// Arrange

            /// Act
            pageModel.OnGet();

            /// Assert
            /// Validates to see if the input data are valid.
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(25, pageModel.Products.Count());
            
        }
        #endregion OnGet
    }
}