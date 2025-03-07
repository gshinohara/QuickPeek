# QuickPeek

## Overview
QuickPeek is a Rhino plugin that displays essential metadata about selected objects in a convenient panel. Users can quickly copy object properties such as layer names, object names, block references, colors, and more.

## Features
- Display metadata of selected objects:
  - Layer Name
  - Object Name
  - Object Color
  - Object Type
  - Object GUID
- Additional information for special cases:
  - Block Name (if applicable)
  - LinkedBlock Reference Source
  - Worksession Attached File
- Copy each property individually or copy all at once
- Integrates as a Rhino panel for easy access

## Installation
1. Download the latest release from the [GitHub Releases](#).
2. Open Rhino and go to `Tools` → `Options` → `Plug-ins`.
3. Click `Install` and select the downloaded .rhp file.
4. Restart Rhino if necessary.

## Usage
1. Select an object in Rhino.
2. Open the QuickPeek panel (`Panels` → `QuickPeek`).
3. View the object metadata in the panel.
4. Click the copy button next to any field to copy its value.

## Development
### Prerequisites
- Rhino 7 (.NET 4.8) or Rhino 8+ (.NET 7.0)
- RhinoCommon and Eto.Forms libraries

### Setup
1. Clone the repository:
   ```sh
   git clone https://github.com/gshinohara/QuickPeek.git
   cd QuickPeek
   ```
2. Open the solution in Visual Studio.
3. Build the project and load it into Rhino.

## Contributing
Contributions are welcome! Feel free to submit issues or pull requests.

## License
This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

