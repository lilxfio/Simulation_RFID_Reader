using System;

/// <summary>
/// Represents an RFID reader used in portal applications. It can scan tags, communicate with tags, and display reader information.
/// Inherits from the <see cref="RFIDReader"/> class.
/// </summary>
public class PortalReader : RFIDReader
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PortalReader"/> class.
    /// </summary>
    /// <param name="readerID">The unique identifier for the RFID reader.</param>
    /// <param name="location">The location where the reader is installed.</param>
    public PortalReader(string readerID, string location)
    {
        ReaderID = readerID;
        Location = location;
    }

    /// <summary>
    /// Initiates the scan operation for detecting RFID tags using the portal reader.
    /// Logs the scanning action to a file.
    /// </summary>
    public override void Scan()
    {
        string message = "Portal Reader scanning...";
        Console.WriteLine(message);
        Logger.Log(message); // Log to file
    }

    /// <summary>
    /// Communicates with the RFID tag and retrieves the tag's information.
    /// Logs the communication message to a file.
    /// </summary>
    /// <param name="tag">The RFID tag that the reader communicates with.</param>
    public override void CommunicateWithTag(RFIDTag tag)
    {
        string message = $"Portal Reader communicates with tag ID: {tag.TagID}";
        Console.WriteLine(message);
        Logger.Log(message); // Log to file
    }

    /// <summary>
    /// Displays the information about the RFID reader, including the reader ID and location.
    /// Logs the reader information to a file.
    /// </summary>
    public override void DisplayReaderInfo()
    {
        string message = $"Reader ID: {ReaderID}\nLocation: {Location}";
        Console.WriteLine(message);
        Logger.Log(message); // Log to file
    }
}
