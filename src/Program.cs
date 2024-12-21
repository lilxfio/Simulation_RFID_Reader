using System;

/// <summary>
/// The main class that demonstrates the functionality of various RFID readers and RFID tags.
/// It creates RFID tags, different types of RFID readers, and simulates scanning and communication with the tags.
/// </summary>
public class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// This method demonstrates the creation of RFID tags, different types of RFID readers,
    /// and simulates the scanning and communication processes.
    /// </summary>
    /// <param name="args">Command-line arguments (not used in this example).</param>
    public static void Main(string[] args)
    {
        // Create RFID tags
        RFIDTag tag1 = new RFIDTag("T123", "Product");
        RFIDTag tag2 = new RFIDTag("T124", "Product");

        // Create different types of RFID readers
        IRFIDReader portalReader = new PortalReader("R001", "Entrance");
        IRFIDReader handheldReader = new HandheldReader("R002", "Warehouse");
        IRFIDReader mountedReader = new MountedReader("R003", "Forklift", "Forklift Equipment");

        // Display Reader Information and Simulate Scanning and Communication
        portalReader.DisplayReaderInfo();
        portalReader.Scan();
        portalReader.CommunicateWithTag(tag1);

        Console.WriteLine("\n");

        handheldReader.DisplayReaderInfo();
        handheldReader.Scan();
        handheldReader.CommunicateWithTag(tag2);

        Console.WriteLine("\n");

        mountedReader.DisplayReaderInfo();
        mountedReader.Scan();
        mountedReader.CommunicateWithTag(tag1);
    }
}
