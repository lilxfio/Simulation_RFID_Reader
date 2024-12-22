# RFID Reader System

## Introduction
The RFID Reader System is a software suite for managing RFID readers and tags. It supports multiple types of readers (handheld, portal, mounted) and provides functionality for scanning, communicating with tags, and logging operations to a CSV file. Unit tests are implemented to ensure the reliability of all core functionalities.

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [System Architecture](#system-architecture)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Testing](#testing)
- [Dependencies](#dependencies)
- [Logging](#logging)
- [Examples](#examples)
- [Troubleshooting](#troubleshooting)
- [Contributors](#contributors)
- [License](#license)

## Features
- **Supports Multiple Reader Types:** Handheld, portal, and mounted readers.
- **RFID Tag Management:** Each tag includes a unique identifier and type (e.g., Product, Asset).
- **Logging Mechanism:** All operations are logged to a CSV file with timestamps.
- **Unit Testing:** Comprehensive test coverage for all components using MSTest and Moq.
- **Extensible Design:** Abstract classes and interfaces allow easy addition of new reader types.

## System Architecture
The project uses an object-oriented architecture:
- **Readers:** `HandheldReader`, `PortalReader`, `MountedReader`, inheriting from the abstract class `RFIDReader`.
- **Tags:** The `RFIDTag` class represents RFID tags with unique identifiers and types.
- **Logger:** A static utility for logging operations to a CSV file.
- **Tests:** Test classes validate functionality for each component, including edge cases and exception handling.

### Class Diagram
 ```bash
    IRFIDReader
  ↳ RFIDReader (Abstract)
       ↳ HandheldReader
       ↳ PortalReader
       ↳ MountedReader
RFIDTag
Logger
Program

 ```
## Installation
1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-repo/rfid-reader-system.git
   cd rfid-reader-system

2. **Build,Restore the Project:** 

    - Open the solution in Visual Studio or use the .NET CLI

     ```bash
         dotnet restore
         dotnet build
     ```

 ## Usage

 1.  **Run the Application:**
     ```bash
        dotnet run
     ```
 2. **Simulate Operations:**    
    - The system creates various RFID readers and tags.
    - Readers scan tags, communicate with them, and log operations.

## Configuration 

- Log File Path: The Logger class writes logs to rfid_log.csv in the application directory. Modify the logFilePath variable in Logger.cs if needed.

## Testing
 #### Overview
The system uses MSTest and Moq for unit testing to ensure the reliability of components. Tests validate the following:
    
- Correct initialization of properties.
- Accurate logging of messages and operations.
- Handling of edge cases, such as exceptions during logging.

 #### Running Tests

1. **Navigate to the Test Directory:** Ensure you are in the project root directory.
2. **Run Tests Using Visual Studio:**
 - Open the solution in Visual Studio.
 - Select **Test > Run All Tests**.

3. **Run Tests Using .NET CLI:**   
  ```bash
      dotnet test
  ```
### Test Coverage    

  **HandheldReaderTests**

- Validates the constructor initializes properties correctly.
- Ensures Scan, CommunicateWithTag, and DisplayReaderInfo log correct messages.
- Uses StringWriter to capture console output for verification.

**LoggerTests**
- Verifies messages are written to the log file with timestamps.
- Tests exception handling during logging operations using mocked TextWriter.

**MountedReaderTests**
- Ensures correct behavior for scanning, communicating with tags, and displaying reader information.

**PortalReaderTests**
- Similar to MountedReaderTests, validates scanning, tag communication, and information display.

**RFIDTagTests**
- Validates initialization of TagID and TagType.
- Uses Moq to mock RFID tag properties for unit testing.  

### Example Test Code
 
 ```bash
     [TestMethod]
public void Scan_ShouldLogMessage()
{
    // Arrange
    var reader = new HandheldReader("R123", "Warehouse");
    var expectedMessage = "Handheld Reader scanning...";

    using (var stringWriter = new StringWriter())
    {
        Console.SetOut(stringWriter);

        // Act
        reader.Scan();

        // Assert
        var output = stringWriter.ToString().Trim();
        Assert.AreEqual(expectedMessage, output);
    }
}
```
## Dependencies

- .NET Framework (>= 6.0)
- MSTest
- Moq

## Logging

- Logs include timestamps and are stored in rfid_log.csv.
- Example log entry:
   ```bash 
       2024-12-22 14:30:00 - Handheld Reader communicates with tag ID: T123
   ```
## Examples
### Creating a Handheld Reader
  ```bash
      IRFIDReader handheldReader = new HandheldReader("R002", "Warehouse");
      handheldReader.DisplayReaderInfo();
      handheldReader.Scan();
      handheldReader.CommunicateWithTag(new RFIDTag("T123", "Product"));
```   

### Logging a Custom Message
 ```bash 
     Logger.Log("Custom log message");
```
## Troubleshooting
- **Log File Issues:** Ensure the application has write permissions to the directory.
- **Reader Not Scanning:** Verify the Scan method is implemented for the reader.
- **Tag Communication Failure:** Confirm the TagID and TagType are properly initialized.

## Contributors

- **Fiordi Toska** - Project Developer
- Contributions welcome! Feel free to submit a pull request or raise an issue.

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.