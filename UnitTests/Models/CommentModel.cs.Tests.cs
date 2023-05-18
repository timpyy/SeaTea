using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    public class CommentModelTests
    {
        [Test]
        public void CommentModel_Id_IsUnique()
        {
            // Arrange
            var comment1 = new CommentModel();
            var comment2 = new CommentModel();

            // Act

            // Assert
            Assert.AreNotEqual(comment1.Id, comment2.Id);
        }

        [Test]
        public void CommentModel_Set_And_Get_Comments()
        {
            // Arrange
            var comment = new CommentModel();
            var expectedComment = "Testing 1,2,3";

            // Act
            comment.Comment = expectedComment;
            var actualComment = comment.Comment;

            // Assert
            Assert.AreEqual(expectedComment, actualComment);
        }

        [Test]
        public void CommentModel_set_Id_IsValid()
        {
            // Arrange
            var comment = new CommentModel();
            var expectedId = "Testing 3,2,1";

            // Act
            comment.Id = expectedId;
            var actualId = comment.Id;

            // Assert
            Assert.AreEqual(expectedId, actualId);
        }
    }
}
