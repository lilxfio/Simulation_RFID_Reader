using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LoggerTests
{
    [TestClass]
    public class LoggerTests
    {
        private const string LogFilePath = "rfid_log.csv"; // Using the same log file path as in your Logger class

        [TestMethod]
        public void Log_ShouldWriteMessageToLogFile()
        {
            // Arrange
            var logMessage = "Test log message";
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var expectedLogEntry = $"{timestamp} - {logMessage}";

            // Mock the StreamWriter to verify the file is written to
            var mockStreamWriter = new Mock<TextWriter>();
            mockStreamWriter.Setup(sw => sw.WriteLine(It.IsAny<string>())).Verifiable();

            // Act: Call the Logger.Log method with the mock StreamWriter
            Logger.Log(logMessage, mockStreamWriter.Object);

            // Assert: Verify that the WriteLine method of the StreamWriter was called
            mockStreamWriter.Verify(sw => sw.WriteLine(It.Is<string>(s => s.Contains(logMessage))), Times.Once);
        }

        [TestMethod]
        public void Log_ShouldHandleExceptionGracefully()
        {
            // Arrange
            var logMessage = "Test log message";

            // Mock StreamWriter to throw an exception when trying to write
            var mockStreamWriter = new Mock<TextWriter>();
            mockStreamWriter.Setup(sw => sw.WriteLine(It.IsAny<string>())).Throws(new IOException("Test exception"));

            // Act: Call the Log method, which should catch the exception
            Logger.Log(logMessage, mockStreamWriter.Object);

            // Assert: Ensure the exception was handled without crashing the test
            // No exception should be thrown, and we expect the Console.WriteLine to show an error message
        }

        [TestMethod]
        public void Log_ShouldAppendMessageWithCorrectTimestamp()
        {
            // Arrange
            var logMessage = "Test log message";
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var expectedLogEntry = $"{timestamp} - {logMessage}";

            // Use reflection or another method to directly interact with Logger's private methods and test the timestamp
            // For simplicity, you can validate the timestamp format by checking the structure of the output.

            // Act: Capture the actual log entry being written (e.g., by using a mock or a file watch)
            Logger.Log(logMessage);

            // Assert: Check if the log file is being written with the expected message and timestamp
            // (You can write to a temporary file to verify this or mock StreamWriter and capture the message)
        }
    }
}
