
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

using Moq;

using ContosoCrafts.WebSite.Services;
using NUnit.Framework.Internal;
// <summary>
/// The purpose of this class is to help test for the unit
/// tests seen throughout the file from the original framework
/// because we want to run a 100% test coverage for our
/// unit test.
/// </summary>
namespace UnitTests
{
    /// <summary>
    /// Helper to hold the web start settings
    ///
    /// HttpClient
    /// 
    /// Action Contect
    /// 
    /// The View Data and Teamp Data
    /// 
    /// The Product Service
    ///
    /// The purpose of this class is to create a test helper
    /// because we want to ensure a 100% on all our unit
    /// testing as a requirement.
    /// </summary>
    public static class TestHelper
    {
        /// <summary>
        /// The classes are turned into static for global use.
        /// </summary>
        public static Mock<IWebHostEnvironment> MockWebHostEnvironment;
        public static IUrlHelperFactory UrlHelperFactory;
        public static DefaultHttpContext HttpContextDefault;
        public static IWebHostEnvironment WebHostEnvironment;
        public static ModelStateDictionary ModelState;
        public static ActionContext ActionContext;
        public static EmptyModelMetadataProvider ModelMetadataProvider;
        public static ViewDataDictionary ViewData;
        public static TempDataDictionary TempData;
        public static PageContext PageContext;
        public static JsonFileProductService ProductService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        static TestHelper()
        {
            //Creates a mock webhost environment for a setup to be used.
            MockWebHostEnvironment = new Mock<IWebHostEnvironment>();
            MockWebHostEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");
            MockWebHostEnvironment.Setup(m => m.WebRootPath).Returns(TestFixture.DataWebRootPath);
            MockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns(TestFixture.DataContentRootPath);

            ///Httpcontextdefault is set equal to trace.
            HttpContextDefault = new DefaultHttpContext()
            {
                TraceIdentifier = "trace",
            };
            HttpContextDefault.HttpContext.TraceIdentifier = "trace";

            //Uses the model state dictionary
            ModelState = new ModelStateDictionary();
            //ActionContext is set using data router, page action descriptor
            //and the state of the model.
            ActionContext = new ActionContext(HttpContextDefault,
                HttpContextDefault.GetRouteData(), new PageActionDescriptor(),
                ModelState);
            ///Empty model data provider is set.
            ModelMetadataProvider = new EmptyModelMetadataProvider();
            ViewData = new ViewDataDictionary(ModelMetadataProvider, ModelState);
            TempData = new TempDataDictionary(HttpContextDefault, Mock.Of<ITempDataProvider>());

            ///New page contage is made to view required data.
            PageContext = new PageContext(ActionContext)
            {
                //View data is set.
                ViewData = ViewData,
                //HttpContext is set.
                HttpContext = HttpContextDefault
            };

            ///Product service is intstantiated to json file.
            ProductService = new JsonFileProductService(MockWebHostEnvironment.Object);

            ///Json file productervice is inititated
            JsonFileProductService productService;

            ///Initiate the test helper to be then used for the following tests
            ///or unit tests in the file.
            productService = new JsonFileProductService(TestHelper.MockWebHostEnvironment.Object);
        }
    }
}
