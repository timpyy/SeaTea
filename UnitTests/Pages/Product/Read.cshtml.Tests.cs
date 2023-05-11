using NUnit.Framework;



using ContosoCrafts.WebSite.Pages.Product;



namespace UnitTests.Pages.Product.Read

{
    //<summary>
    //The purpose of this class is to run a read test
    //on the read method because we want to have a 100%
    //coverage for our unit tests.
    //</summary>
    public class ReadTests

    {

        #region TestSetup
        //Sets up the testing environment
        public static ReadModel pageModel;



        [SetUp]
        //Initilizes the unit test using the TestHelper class.
        public void TestInitialize()

        {

            pageModel = new ReadModel(TestHelper.ProductService)

            {

            };

        }



        #endregion TestSetup



        #region OnGet

        [Test]
        //Applies Unit Tests to the read method for the website. 
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

    }

}





