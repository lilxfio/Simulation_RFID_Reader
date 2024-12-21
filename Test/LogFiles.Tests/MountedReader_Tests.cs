using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RFIDReaderTests
{
    [TestClass]
    public class MountedReaderTests
    {
        // Test for Scan method
        [TestMethod]
        public void Scan_ShouldLogMessage()
        {
            // Arrange
            var reader = new MountedReader("R123", "Warehouse", "Conveyor");
            var expectedMessage = "Mounted Reader scanning...";

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
            var reader = new MountedReader("R123", "Warehouse", "Conveyor");
            var tag = new RFIDTag("T123", "TypeA");  // Ensure RFIDTag is properly initialized
            var expectedMessage = $"Mounted Reader communicates with tag ID: {tag.TagID}";

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

        // Test for DisplayReaderInfo method
        [TestMethod]
        public void DisplayReaderInfo_ShouldLogMessage()
        {
            // Arrange
            var reader = new MountedReader("R123", "Warehouse", "Conveyor");
            var expectedMessage = $"Reader ID: {reader.ReaderID}\nLocation: {reader.Location}\nMounted on Equipment: {reader.Equipment}";

            // Capture the output
            using (var stringWriter = new StringWriter())
            {
                // Redirect Console output to StringWriter
                Console.SetOut(stringWriter);

                // Act
                reader.DisplayReaderInfo();

                // Assert
                var output = stringWriter.ToString().Trim();
                Assert.IsTrue(output.Contains(expectedMessage), $"Expected to contain: '{expectedMessage}', but got: '{output}'");
            }
        }
    }
}
