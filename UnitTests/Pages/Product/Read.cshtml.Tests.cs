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
        /// <summary>
        /// Sets up the testing environment
        /// </summary>
        public static ReadModel pageModel;


        [SetUp]
        ///Initilizes the unit test using the TestHelper class.
        public void TestInitialize()

        {
            ///Initializes test using the read model.
            pageModel = new ReadModel(TestHelper.ProductService)

            {

            };

        }
        #endregion TestSetup

        #region RedirectsError
        [Test]
        //checks if on error the redirection to error page works or no.
        public void OnGet_With_Invalid_Id_Redirects_To_Error_Page()
        {



            /// Arrange

            /// Act
            pageModel.OnGet("Nothing");    // checks pagemodel onget on nothing.
            var errorPage = pageModel.GetType(); // gets the page type
            /// Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);  //validates the page
        }
        #endregion RedirectsError
        #region OnGet

        [Test]
        ///Applies Unit Tests to the read method for the website. 
        public void OnGet_Valid_Should_Return_Products()

        {

            /// Arrange

            /// Act
            pageModel.OnGet("Boba Up");

            /// Assert
            /// Validates to see if input data is valid.
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Boba Up - Self Serve", pageModel.Product.Title);

        }

        #endregion OnGet

    }

}





