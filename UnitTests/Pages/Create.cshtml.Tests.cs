using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;


namespace UnitTests.Pages.Product.Create
{
    //<summary>
    //The purpose of this class is to run a unit test
    //on the Create method because we want to have a 100%
    //coverage for our unit tests.
    //</summary>
    public class CreateTests
    {
        //Sets up the testing environment
        #region TestSetup

        //Inititates pagemodel to a CreateModel object
        public static CreateModel pageModel;

        [SetUp]
        //Initilizes the unit test using the TestHelper class.
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
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
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount + 1, TestHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet
    }
}