using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RFIDTagTests
{
    [TestClass]
    public class RFIDTagTests
    {
        // Test for TagID and TagType properties
        [TestMethod]
        public void RFIDTag_Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string expectedTagID = "T123";
            string expectedTagType = "TypeA";

            // Act
            var tag = new RFIDTag(expectedTagID, expectedTagType);

            // Assert
            Assert.AreEqual(expectedTagID, tag.TagID, "TagID should be set correctly.");
            Assert.AreEqual(expectedTagType, tag.TagType, "TagType should be set correctly.");
        }

        // Test for DisplayTagInfo method
        [TestMethod]
        public void DisplayTagInfo_ShouldLogTagDetails()
        {
            // Arrange
            string tagID = "T123";
            string tagType = "TypeA";
            var tag = new RFIDTag(tagID, tagType);
            var expectedTagIDMessage = $"Tag ID: {tagID}";
            var expectedTagTypeMessage = $"Tag Type: {tagType}";

            // Capture the output
            using (var stringWriter = new StringWriter())
            {
                // Redirect Console output to StringWriter
                Console.SetOut(stringWriter);

                // Act
                tag.DisplayTagInfo();

                // Assert
                var output = stringWriter.ToString().Trim();
                Assert.IsTrue(output.Contains(expectedTagIDMessage), $"Expected to contain: '{expectedTagIDMessage}', but got: '{output}'");
                Assert.IsTrue(output.Contains(expectedTagTypeMessage), $"Expected to contain: '{expectedTagTypeMessage}', but got: '{output}'");
            }
        }

        // Test for mocking RFIDTag using Moq
        [TestMethod]
        public void RFIDTag_Mock_ShouldReturnMockedValues()
        {
            // Arrange
            var mockTag = new Mock<RFIDTag>("T123", "TypeA");
            mockTag.Setup(tag => tag.TagID).Returns("MockedTagID");
            mockTag.Setup(tag => tag.TagType).Returns("MockedTagType");

            // Act
            var tagID = mockTag.Object.TagID;
            var tagType = mockTag.Object.TagType;

            // Assert
            Assert.AreEqual("MockedTagID", tagID, "Mocked TagID should be returned.");
            Assert.AreEqual("MockedTagType", tagType, "Mocked TagType should be returned.");
        }
    }
}
