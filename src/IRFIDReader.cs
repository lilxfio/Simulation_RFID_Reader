using System;

/// <summary>
/// Defines the contract for an RFID reader that can scan tags, communicate with tags, and display reader information.
/// </summary>
public interface IRFIDReader
{
    /// <summary>
    /// Initiates a scan for RFID tags.
    /// </summary>
    void Scan();

    /// <summary>
    /// Communicates with a specific RFID tag.
    /// </summary>
    /// <param name="tag">The RFID tag that the reader will communicate with.</param>
    void CommunicateWithTag(RFIDTag tag);

    /// <summary>
    /// Displays the information about the RFID reader.
    /// </summary>
    void DisplayReaderInfo();
}
