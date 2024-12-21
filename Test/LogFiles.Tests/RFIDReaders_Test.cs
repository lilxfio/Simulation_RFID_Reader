using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RFIDReaderTests
{
    // A mock subclass of RFIDReader for testing purposes
    public class TestRFIDReader : RFIDReader
    {
        public TestRFIDReader(string readerID, string location)
        {
            ReaderID = readerID;
            Location = location;
        }

        public override void Scan()
        {
            // Implementing Scan with a simple message
            Console.WriteLine("Scanning...");
        }

        public override void CommunicateWithTag(RFIDTag tag)
        {
            // Implementing CommunicateWithTag with a simple message
            Console.WriteLine($"Communicating with tag ID: {tag.TagID}");
        }
    }

    [TestClass]
    public class RFIDReaderTests
    {
        // Test for DisplayReaderInfo method
        [TestMethod]
        public void DisplayReaderInfo_ShouldLogReaderDetails()
        {
            // Arrange
            var reader = new TestRFIDReader("R123", "Warehouse");
            var expectedReaderIDMessage = $"Reader ID: {reader.ReaderID}";
            var expectedLocationMessage = $"Location: {reader.Location}";

            // Capture the output
            using (var stringWriter = new StringWriter())
            {
                // Redirect Console output to StringWriter
                Console.SetOut(stringWriter);

                // Act
                reader.DisplayReaderInfo();

                // Assert
                var output = stringWriter.ToString().Trim();
                Assert.IsTrue(output.Contains(expectedReaderIDMessage), $"Expected to contain: '{expectedReaderIDMessage}', but got: '{output}'");
                Assert.IsTrue(output.Contains(expectedLocationMessage), $"Expected to contain: '{expectedLocationMessage}', but got: '{output}'");
            }
        }

        // Test for Scan method (this is just testing the base implementation in the mock)
        [TestMethod]
        public void Scan_ShouldLogMessage()
        {
            // Arrange
            var reader = new TestRFIDReader("R123", "Warehouse");
            var expectedMessage = "Scanning...";

            // Capture the output
            using (var stringWriter = new StringWriter())
            {
                // Redirect Console output to StringWriter
                Console.SetOut(stringWriter);

                // Act
                reader.Scan();

                // Assert
                var output = stringWriter.ToString().Trim();
                Assert.IsTrue(output.Contains(expectedMessage), $"Expected to contain: '{expectedMessage}', but got: '{output}'");
            }
        }

        // Test for CommunicateWithTag method
        [TestMethod]
        public void CommunicateWithTag_ShouldLogMessage()
        {
            // Arrange
            var reader = new TestRFIDReader("R123", "Warehouse");
            var tag = new RFIDTag("T123", "TypeA");  // Ensure RFIDTag is properly initialized
            var expectedMessage = $"Communicating with tag ID: {tag.TagID}";

            // Capture the output
            using (var stringWriter = new StringWriter())
            {
                // Redirect Console output to StringWriter
                Console.SetOut(stringWriter);

                // Act
                reader.CommunicateWithTag(tag);

                // Assert
                var output = stringWriter.ToString().Trim();
                Assert.IsTrue(output.Contains(expectedMessage), $"Expected to contain: '{expectedMessage}', but got: '{output}'");
            }
        }
    }
}
