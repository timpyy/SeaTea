using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;
using System.Linq;

namespace UnitTests.Pages.Index
{
    //<summary>
    //The purpose of this class is to run a index test
    //on the index method because we want to have a 100%
    //coverage for our unit tests.
    //</summary>
    public class IndexTests
    {
        #region TestSetup
        public static IndexModel pageModel;

        //Initializes the test for setup using the MockLoggerDirect.
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            pageModel = new IndexModel(MockLoggerDirect, TestHelper.ProductService)
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
        #region OnGet
        /// <summary>
        /// Unit test for checking valid search string returns corresponding product
        /// </summary>
        [Test]
        public void OnGet_Should_Return_All_Products()
        {
            // Arrange



            // Act
            pageModel.OnGet();



            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(23, pageModel.Products.Count());
            
        }
        #endregion OnGet
    }
}