using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    ///The purpose of this file is to unit test for
    ///comment model because we want to get 100%
    ///on unit testing.
    public class CommentModelTests
    {
        [Test]
        ///This class test for the id of the comment model.
        public void CommentModel_Id_IsUnique()
        {
            /// Arrange
            var comment1 = new CommentModel();
            var comment2 = new CommentModel();

            /// Act

            /// Assert
            /// Validates if inputs are indeed valid.
            Assert.AreNotEqual(comment1.Id, comment2.Id);
        }

        [Test]
        ///This class tests for the set and get comments.
        public void CommentModel_Set_And_Get_Comments()
        {
            /// Arrange
            var comment = new CommentModel();
            var expectedComment = "Testing 1,2,3";

            /// Act
            comment.Comment = expectedComment;
            var actualComment = comment.Comment;

            /// Assert
            /// Validates if inputs are indeed valid.
            Assert.AreEqual(expectedComment, actualComment);
        }

        [Test]
        ///This class unit tests to see if the set ID is valid.
        public void CommentModel_set_Id_IsValid()
        {
            /// Arrange
            var comment = new CommentModel();
            var expectedId = "Testing 3,2,1";

            /// Act
            comment.Id = expectedId;
            var actualId = comment.Id;

            /// Assert
            /// Validates if inputs are indeed valid.
            Assert.AreEqual(expectedId, actualId);
        }
    }
}
