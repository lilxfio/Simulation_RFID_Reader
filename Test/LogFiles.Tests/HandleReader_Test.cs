using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Moq;

namespace RFIDReaderTests
{
    [TestClass]
    public class HandheldReaderTests
    {
        private const string TestReaderID = "Reader123";
        private const string TestLocation = "Warehouse A";

        private HandheldReader? handheldReader;

        [TestInitialize]
        public void Setup()
        {
            // Initialize HandheldReader before each test
            handheldReader = new HandheldReader(TestReaderID, TestLocation);
        }

        [TestMethod]
        public void Constructor_ShouldInitializeProperties()
        {
            // Assert
            Assert.AreEqual(TestReaderID, handheldReader!.ReaderID);
            Assert.AreEqual(TestLocation, handheldReader.Location);
        }

        [TestMethod]
        public void Scan_ShouldLogMessage()
        {
            // Arrange
            var expectedMessage = "Handheld Reader scanning...";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                handheldReader!.Scan();

                // Assert
                var consoleOutput = sw.ToString().Trim();
                Assert.AreEqual(expectedMessage, consoleOutput);
            }
        }

        [TestMethod]
public void CommunicateWithTag_ShouldLogMessageWithTagID()
{
    // Arrange
    var tagID = "Tag456";
    var tagType = "TypeA";

    // Create a mock for RFIDTag and set up its virtual properties
    var mockTag = new Mock<RFIDTag>(tagID, tagType);
    mockTag.Setup(t => t.TagID).Returns(tagID);  // Mock the TagID property
    mockTag.Setup(t => t.TagType).Returns(tagType);  // Mock the TagType property

    var expectedMessage = $"Handheld Reader communicates with tag ID: {tagID}";

    using (var sw = new StringWriter())
    {
        Console.SetOut(sw);

        // Act
        handheldReader!.CommunicateWithTag(mockTag.Object);

        // Assert
        var consoleOutput = sw.ToString().Trim();
        Assert.AreEqual(expectedMessage, consoleOutput);
    }
}


        [TestMethod]
        public void DisplayReaderInfo_ShouldLogReaderInfo()
        {
            // Arrange
            var expectedMessage = $"Reader ID: {TestReaderID}\nLocation: {TestLocation}";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                handheldReader!.DisplayReaderInfo();

                // Assert
                var consoleOutput = sw.ToString().Trim();
                Assert.AreEqual(expectedMessage, consoleOutput);
            }
        }
    }
}
