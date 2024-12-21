using System;

/// <summary>
/// An abstract class representing a generic RFID reader. 
/// This class implements the <see cref="IRFIDReader"/> interface and defines common properties and methods for RFID readers.
/// </summary>
public abstract class RFIDReader : IRFIDReader
{
    /// <summary>
    /// Gets or sets the unique identifier for the RFID reader.
    /// </summary>
    public string? ReaderID { get; set; }

    /// <summary>
    /// Gets or sets the location where the RFID reader is installed or placed.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Initiates the scan operation to detect RFID tags.
    /// This method must be implemented by subclasses.
    /// </summary>
    public abstract void Scan();

    /// <summary>
    /// Communicates with an RFID tag and retrieves its information.
    /// This method must be implemented by subclasses.
    /// </summary>
    /// <param name="tag">The RFID tag to communicate with.</param>
    public abstract void CommunicateWithTag(RFIDTag tag);

    /// <summary>
    /// Displays information about the RFID reader, including the reader ID and location.
    /// This method provides default behavior, but can be overridden in derived classes.
    /// </summary>
    public virtual void DisplayReaderInfo()
    {
        Console.WriteLine($"Reader ID: {ReaderID}");
        Console.WriteLine($"Location: {Location}");
    }
}
