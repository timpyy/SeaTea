using Bunit;
using NUnit.Framework;

namespace UnitTests
{
    // <summary>
    // The purpose of this class is to test the BUnitHelper
    // because we want to run a 100% test coverage for our
    // unit test.
    // </summary>
    public abstract class BunitTestContext : TestContextWrapper
    {
        // The Setup sets the context
        [SetUp]
        public void Setup() => TestContext = new Bunit.TestContext();

        // When done displose removes it, to free up system resources
        [TearDown]
        public void TearDown() => TestContext.Dispose();
    }
}