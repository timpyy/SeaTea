using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

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
        #region Serialize
        [Test]
        //Applies a unit test validation on the Json toString serialization.
        public void Valid_Serialization()
        {
            // Arrange
            var product = TestHelper.ProductService.CreateData();
            var settings = new JsonSerializerSettings
            {
                // Added Json Serialization setting to handle single quotation marks in strings
                StringEscapeHandling = StringEscapeHandling.EscapeHtml
            };
            // Serializes the data using the new settings
            var expectedJson = JsonConvert.SerializeObject(product, settings);

            // Act
            var actualResult = product.ToString();

            // Assert
            Assert.AreEqual(expectedJson, actualResult);
        }
    }
    #endregion Serialize

}

