using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;



namespace UnitTests.Pages.Listing
{
    public class ListingTests
    {
        #region TestSetup
        public static PageContext pageContext;



        public static ListingModel pageModel;



        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ListingModel(TestHelper.ProductService)
            {
            };
        }



        #endregion TestSetup



        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange



            // Act
            pageModel.OnGet();



            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true,pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}