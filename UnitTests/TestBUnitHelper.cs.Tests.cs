using Bunit;
using NUnit.Framework;

namespace UnitTests
{

    [TestFixture]
    //<<<Summary>>>
    // The purpose of this class is to create a testContext class that is a child of the 
    // BunitTestContext to that we can have the appropriate credentials to test the SetUp and TearDown
    // functions within the BunitTestContext
    // <<</Summary>>>

    public class testContext : BunitTestContext
    {
    }
    //<<<Summary>>>
    // The purpose of this class is to run the testContext class SetUp and TearDown functions
    // to ensure that the when UnitTest creates a TestBUnitHelper the classes functions are valid
    // <<</Summary>>>
    public class BunitTestSetupTests
    {
        private testContext _testContext;
        [SetUp]
        public void SetUp()
        {
            // Create an instance of the testContext class
            _testContext = new testContext();
        }
        [TearDown]
        public void TearDown()
        {
            // Call the TearDown function to ensure it is valid
            _testContext.TearDown();
        }
        [Test]
        // Ensure that SetUp creates a valid BunitTestContext object
        public void SetUpIsValid()
        {
            // Arrange

            // Act
            _testContext.Setup();

            // Assert
            Assert.NotNull(_testContext);
        }
    }
}

