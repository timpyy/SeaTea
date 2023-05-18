using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Linq;
using NUnit.Framework.Internal;



namespace UnitTests.Services
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup


        /// <summary>
        /// The purpose of this file is to develop
        /// a storage to which the data will go to
        /// which is JsonFile because we want to store our
        /// data effecienctly.
        /// </summary>
        [SetUp]

        ///Initializes the test set up.
        public void TestInitialize()
        {
        }



        #endregion TestSetup



        #region AddRating



       /// <summary>
       /// Test for update to rating
       /// </summary>
        [Test]
        public void AddRating_Valid_Rating_Valid_Should_Return_Updated_Rating()
        {
            /// Arrange
            // Data is set to get the first product.
            var data = TestHelper.ProductService.GetProducts().First();
            var countOriginal = data.Ratings.Length;



            /// Act
            TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetProducts().First();



            /// Assert
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }



        /// <summary>
        /// test for initialization
        /// </summary>
        [Test]
        public void AddRating_Valid_Rating_Added_To_Null_Ratings_Should_Return_New_Initialized_Value()
        {
            /// Arrange
            // Data is set to get the last product.
            var data = TestHelper.ProductService.GetProducts().Last();
            data.Ratings = null;
            int rating = 5;



            /// Act
            TestHelper.ProductService.AddRating(data.Id, rating);
            var dataNewList = TestHelper.ProductService.GetProducts().First();



            /// Assert
            Assert.AreEqual(rating, dataNewList.Ratings.Last());
        }



        #endregion AddRating



        #region DeleteData
        [Test]
        public void Valid_DataId_Returns_Different_First_Valie_From_List()
        {
            /// Arrange
            // Data is set to get the the products.
            var DataSet = TestHelper.ProductService.GetProducts();
            var DataF = TestHelper.ProductService.GetProducts().First();



            /// Act
            TestHelper.ProductService.DeleteData(DataF.Id);
            var dataNewList = TestHelper.ProductService.GetProducts().First();
            var DataF2 = TestHelper.ProductService.GetProducts().First();


            /// Assert
            /// Validates if input are valid.
            Assert.AreNotEqual(DataF, DataF2);
        }
        #endregion DeletePilot



        #region UpdateData



        [Test]
        public void UpdateData_Valid_Updated_Value_Matches_Should_Return_True()
        {



            /// Arrange
            // Data is set to get the first product for default.
            var data = TestHelper.ProductService.GetProducts().FirstOrDefault();
            var data2 = data;
            data2.Title = "Test";



            /// Act
            var result = TestHelper.ProductService.UpdateData(data2);



            /// Reset
            _ = TestHelper.ProductService.UpdateData(data);



            // Assert
            /// Validates if input are valid.
            Assert.AreEqual(data2.Title, result.Title);
        }



        [Test]
        public void UpdateData_Null_Data_Value_Should_Return_Null()
        {



            // Arrange
            // Data is set to get the first product for default.
            var data = TestHelper.ProductService.GetProducts().FirstOrDefault();
            var data2 = data;
            data2.Id = null;



            // Act
            var result = TestHelper.ProductService.UpdateData(data2);



            // Assert
            /// Validates if input are valid.
            Assert.AreEqual(null, result);
        }
        #endregion UpdateData



        #region CreateData



        [Test]
        public void CreateData_Valid_Updated_Value_Matches_Should_Return_True()
        {



            /// Arrange
            // Data is set to get the first product for default.
            var data = TestHelper.ProductService.GetProducts().FirstOrDefault();
            var data2 = data;
            data2.Title = "Test";



            /// Act
            var result = TestHelper.ProductService.CreateData();
            result.Title = "Test";



            /// Assert
            /// Validates if input are valid.
            Assert.AreEqual(data2.Title, result.Title);
        }
        #endregion CreateData
    }
}