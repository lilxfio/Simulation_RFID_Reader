using System;

/// <summary>
/// Represents an RFID reader mounted on a specific equipment, which can scan tags, communicate with them, and display reader information.
/// Inherits from the <see cref="RFIDReader"/> class.
/// </summary>
public class MountedReader : RFIDReader
{
    /// <summary>
    /// Gets or sets the equipment on which the reader is mounted.
    /// </summary>
    public string Equipment { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MountedReader"/> class.
    /// </summary>
    /// <param name="readerID">The unique identifier for the RFID reader.</param>
    /// <param name="location">The location where the reader is installed.</param>
    /// <param name="equipment">The name of the equipment to which the reader is mounted.</param>
    public MountedReader(string readerID, string location, string equipment)
    {
        ReaderID = readerID;
        Location = location;
        Equipment = equipment;
    }

    /// <summary>
    /// Initiates the scan operation for detecting RFID tags using the mounted reader.
    /// Logs the scanning action to a file.
    /// </summary>
    public override void Scan()
    {
        string message = "Mounted Reader scanning...";
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
        string message = $"Mounted Reader communicates with tag ID: {tag.TagID}";
        Console.WriteLine(message);
        Logger.Log(message); // Log to file
    }

    /// <summary>
    /// Displays the information about the RFID reader, including the reader ID, location, and the equipment it is mounted on.
    /// Logs the reader information to a file.
    /// </summary>
    public override void DisplayReaderInfo()
    {
        string message = $"Reader ID: {ReaderID}\nLocation: {Location}\nMounted on Equipment: {Equipment}";
        Console.WriteLine(message);
        Logger.Log(message); // Log to file
    }
}
