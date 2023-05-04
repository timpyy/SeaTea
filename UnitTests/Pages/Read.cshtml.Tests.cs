using NUnit.Framework;



using ContosoCrafts.WebSite.Pages;



namespace UnitTests.Pages.Read

{

    public class ReadTests

    {

        #region TestSetup

        public static ReadModel pageModel;



        [SetUp]

        public void TestInitialize()

        {

            pageModel = new ReadModel(TestHelper.ProductService)

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

            pageModel.OnGet("Boba Up");



            // Assert

            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual("Boba Up - Self Serve", pageModel.Product.Title);

        }

        #endregion OnGet

    }

}





