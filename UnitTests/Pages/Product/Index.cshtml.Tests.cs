using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;



namespace UnitTests.Pages.Listing
{
    //<summary>
    //The purpose of this class is to run a unit test
    //on the index method because we want to have a 100%
    //coverage for our unit tests.
    //</summary>
    public class ListingTests
    {
        #region TestSetup
        public static PageContext pageContext;

        //Inititates pagemodel to a ListingModel object
        public static ListingModel pageModel;



        [SetUp]
        //Initilizes the unit test using the TestHelper class.
        public void TestInitialize()
        {
            pageModel = new ListingModel(TestHelper.ProductService)
            {
            };
        }



        #endregion TestSetup



        #region OnGet
        [Test]
        //Applies Unit Tests to the listing(index) method for the website. 
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