using System;

/// <summary>
/// Represents a handheld RFID reader that can scan tags and communicate with them.
/// Inherits from the <see cref="RFIDReader"/> class.
/// </summary>
public class HandheldReader : RFIDReader
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HandheldReader"/> class.
    /// </summary>
    /// <param name="readerID">The unique identifier of the RFID reader.</param>
    /// <param name="location">The physical location of the RFID reader.</param>
    public HandheldReader(string readerID, string location)
    {
        ReaderID = readerID;
        Location = location;
    }

    /// <summary>
    /// Scans for RFID tags using the handheld reader.
    /// Logs the scanning message to a file.
    /// </summary>
    public override void Scan()
    {
        string message = "Handheld Reader scanning...";
        Console.WriteLine(message);
        Logger.Log(message); // Log to file
    }

    /// <summary>
    /// Communicates with a specific RFID tag.
    /// Logs the communication message to a file.
    /// </summary>
    /// <param name="tag">The RFID tag that the reader communicates with.</param>
    public override void CommunicateWithTag(RFIDTag tag)
    {
        string message = $"Handheld Reader communicates with tag ID: {tag.TagID}";
        Console.WriteLine(message);
        Logger.Log(message); // Log to file
    }

    /// <summary>
    /// Displays the information about the RFID reader.
    /// Logs the reader information to a file.
    /// </summary>
    public override void DisplayReaderInfo()
    {
        string message = $"Reader ID: {ReaderID}\nLocation: {Location}";
        Console.WriteLine(message);
        Logger.Log(message); // Log to file
    }
}
