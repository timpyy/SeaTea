using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace UnitTests.Models.CommentModel
{
    //<summary>
    //The purpose of this class is to run a unit test
    //on the productModel object because we want to have a 100%
    //coverage for our unit tests.
    //</summary>
    public class CommentModelTests
    {
        #region TestSetup
        //Setup the testing environment
        public static CreateModel CommentModel;
        [SetUp]
        public void testInitialize()
        {
            CommentModel = new CreateModel(TestHelper.ProductService) { };
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
            CommentModel.OnGet();

            // Assert
            Assert.AreEqual(true, CommentModel.ModelState.IsValid);
            Assert.AreEqual(oldCount + 1, TestHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet
        #region Serialize
        [Test]
        //Applies a unit test validation on the Json toString serialization.
        public void Valid_Serialization()
        {
            // Arrange
            var comment = TestHelper.ProductService.CreateData();
            var settings = new JsonSerializerSettings
            {
                // Added Json Serialization setting to handle single quotation marks in strings
                StringEscapeHandling = StringEscapeHandling.EscapeHtml
            };
            // Serializes the data using the new settings
            var expectedJson = JsonConvert.SerializeObject(comment, settings);

            // Act
            var actualResult = comment.ToString();

            // Assert
            Assert.AreEqual(expectedJson, actualResult);
        }
    }
    #endregion Serialize

}
