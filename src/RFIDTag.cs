using System;

/// <summary>
/// Represents an RFID tag with a unique identifier and a type. 
/// This class provides functionality to display the tag's information.
/// </summary>
public class RFIDTag
{
    /// <summary>
    /// Gets or sets the unique identifier for the RFID tag.
    /// This property is virtual to allow mocking in unit tests using Moq.
    /// </summary>
    public virtual string TagID { get; set; }

    /// <summary>
    /// Gets or sets the type of the RFID tag (e.g., Product, Asset).
    /// This property is virtual to allow mocking in unit tests using Moq.
    /// </summary>
    public virtual string TagType { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RFIDTag"/> class with a specified tag ID and tag type.
    /// </summary>
    /// <param name="tagID">The unique identifier of the RFID tag.</param>
    /// <param name="tagType">The type of the RFID tag (e.g., Product, Asset).</param>
    public RFIDTag(string tagID, string tagType)
    {
        TagID = tagID;
        TagType = tagType;
    }

    /// <summary>
    /// Displays the information about the RFID tag, including its ID and type.
    /// </summary>
    public void DisplayTagInfo()
    {
        Console.WriteLine($"Tag ID: {TagID}");
        Console.WriteLine($"Tag Type: {TagType}");
    }
}
