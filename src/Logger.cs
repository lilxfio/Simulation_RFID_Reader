using System;
using System.IO;

/// <summary>
/// A static class responsible for logging messages to a CSV file.
/// Logs are written with timestamps to the file specified by <see cref="logFilePath"/>.
/// </summary>
public static class Logger
{
    /// <summary>
    /// The path to the log file where messages are appended.
    /// </summary>
    private static readonly string logFilePath = "rfid_log.csv"; // Log file path

    /// <summary>
    /// Logs a message to the log file with a timestamp.
    /// Optionally accepts a custom <see cref="TextWriter"/> to write the message (useful for testing).
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="writer">A custom <see cref="TextWriter"/> for output, defaults to <see cref="StreamWriter"/> writing to the log file.</param>
    /// <remarks>
    /// If no <paramref name="writer"/> is provided, the method uses a default <see cref="StreamWriter"/> to write to the log file.
    /// </remarks>
    public static void Log(string message, TextWriter writer = null!)
    {
        writer ??= new StreamWriter(logFilePath, true); // Use default StreamWriter if no writer is passed

        try
        {
            // Append the log message with a timestamp
            writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
        catch (Exception ex)
        {
            // If an error occurs while writing to the log, display it to the console
            Console.WriteLine($"Error writing to log: {ex.Message}");
        }
        finally
        {
            // Ensure the writer is properly disposed to release resources
            writer?.Dispose();
        }
    }
}
