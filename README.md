# Revit Basic Plugin with FastAPI Backend

This repository contains a basic Revit plugin and a companion FastAPI backend server.

---

## 1. Revit Basic Plugin Setup

This section describes how to build and set up the Revit plugin.

### Prerequisites

*   Revit 2026 installed on your system.
*   Visual Studio (2019 or later recommended) with .NET desktop development workload.

### Build Instructions

1.  **Open the Solution:**
    Navigate to the `src/` directory and open the `Revit_Basic_Plugin.sln` file in Visual Studio.

    ```bash
    cd src/
    start Revit_Basic_Plugin.sln
    ```

2.  **Build the Project:**
    In Visual Studio, right-click on the `Revit_Basic_Plugin` project in the Solution Explorer and select "Build". Alternatively, go to `Build > Build Solution` from the top menu.

    This will compile the plugin and generate the necessary `.dll` files.

3.  **Install the Plugin:**
    For Revit to load your plugin, the `.addin` file needs to be placed in a specific Revit Add-Ins folder.

    *   **Modify the `.addin` file:**
        Replace `PATH_TO_REPOSITORY` with the actual path to your repository.

    *   **Place the `.addin` file:**
        Copy this `.addin` file into one of Revit's Add-Ins folders. Common locations include:
        *   `C:\ProgramData\Autodesk\Revit\Addins\2026\`
        *   `%APPDATA%\Autodesk\Revit\Addins\2026\`

4.  **Launch Revit:**
    Start Revit. Your plugin should now be available.

---

## 2. FastAPI Backend Server Setup

This section describes how to set up and run the FastAPI server.

### Prerequisites

*   Python 3.7+ installed.
*   `pip` (Python package installer).

### Setup Instructions

1.  **Navigate to the FastAPI directory:**
    Open your terminal or command prompt and change your current directory to the `fastapi/` folder.

    ```bash
    cd fastapi/
    ```

2.  **Install dependencies:**
    Install all required Python packages using `pip`.

    ```bash
    pip install -r requirements.txt
    ```

3.  **Start the server:**
    Run the FastAPI application.

    ```bash
    fastapi dev main.py
    ```

    You should see output indicating that the server has started, usually on `http://127.0.0.1:8000`.



# Implementation

The plugin's entrypoint is RevitBasicApplication, which implements the IExternalApplication interface and registers the tab, panel, and the dockable pane.  
The dockable pane is implemented using a XAML file, containing the layout data, and a C# file for the functionality.  
The dockable pane is toggled by the ShowMainPanelDockableCommand, which implements the IExternalCommand interface.  

The server is implemented using a standard POST endpoint from the FastAPI package.