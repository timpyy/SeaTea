using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;



namespace UnitTests.Pages.Product.Update

{
    //<summary>
    //The purpose of this class is to run a update test
    //on the update method because we want to have a 100%
    //coverage for our unit tests.
    //</summary>
    public class UpdateTests

    {

        #region TestSetup
        //Sets up the testing environment
        public static UpdateModel pageModel;



        [SetUp]
        //Initilizes the unit test using the TestHelper class.
        public void TestInitialize()

        {

            pageModel = new UpdateModel(TestHelper.ProductService)

            {

            };

        }



        #endregion TestSetup



        #region OnGet

        [Test]
        //Applies Unit Tests to the update method for the website.
        public void OnGet_Valid_Should_Return_Products()

        {

            // Arrange

            // Act

            pageModel.OnGet("Boba Up");

            // Assert

            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual("Boba Up - Self Serve", pageModel.Product.Title);

        }

        #endregion OnGet


        #region OnPost

        [Test]

        //Applies Unit Tests to the read method for the website if onpost
        //is valid.
        public void OnPost_Valid_Should_Return_Products()

        {

            // Arrange

            pageModel.Product = new ProductModel

            {

                Id = "Boba Up",

                Title = "title",

                Description = "description",

                Url = "url",

                Image = "image"

            };



            // Act

            var result = pageModel.OnPost() as RedirectToPageResult;



            // Assert

            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(true, result.PageName.Contains("Listing"));

        }



        [Test]

        //Applies Unit Tests to the read method for the website if
        //the onpost is invalid.
        public void OnPost_InValid_Model_NotValid_Return_Page()

        {

            // Arrange



            // Force an invalid error state

            pageModel.ModelState.AddModelError("bogus", "bogus error");



            // Act

            var result = pageModel.OnPost() as ActionResult;



            // Assert

            Assert.AreEqual(false, pageModel.ModelState.IsValid);

        }

        #endregion OnPost

    }

}





