using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Models.ProductModel
{
    //<summary>
    //The purpose of this class is to run a unit test
    //on the productModel object because we want to have a 100%
    //coverage for our unit tests.
    //</summary>
    public class ProductModelTests
    {
        #region TestSetup
        //Setup the testing environment
        public static CreateModel ProductModel;
        [SetUp]
        public void testInitialize()
        {
            ProductModel = new CreateModel(TestHelper.ProductService) { };
        }
        #endregion TestSetup


        #region OnGet
        [Test]
        //Applies Unit Tests to the create method for the website. 
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var oldCount = TestHelper.ProductService.GetAllData().Count();

            // Act
            ProductModel.OnGet();

            // Assert
            Assert.AreEqual(true, ProductModel.ModelState.IsValid);
            Assert.AreEqual(oldCount + 1, TestHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet

    }
}
