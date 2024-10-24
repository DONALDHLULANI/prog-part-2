Contract Monthly Claim System (CMCS) - README
---------------------------------------------

Overview
--------
This is the Contract Monthly Claim System (CMCS), a WPF-based desktop application designed to assist lecturers in submitting monthly claims and track their status. It provides interfaces for submitting, verifying, and managing claim statuses.

Prerequisites
-------------
Before running the application, ensure the following are installed on your machine:

- .NET Framework 4.8 or higher
- Visual Studio 2022 with WPF components installed
- Git for cloning the repository
- Windows OS (since it's a WPF application)

Cloning and Running the Application
-----------------------------------

Step 1: Clone the Repository
----------------------------
1. Open your terminal or Git Bash.
2. Navigate to the directory where you want to clone the repository.
3. Run the following command to clone the repository to your local drive:

    
    git clone https://github.com/username/CMCS.git
    
    Replace `username` with the actual GitHub username if necessary.

4. Once cloned, navigate into the project folder:

    cd CMCS


Step 2: Open the Project in Visual Studio
-----------------------------------------
1. Launch Visual Studio 2022.
2. From the menu, select File > Open > Project/Solution.
3. Navigate to the cloned repository's directory and open the `CMCS.sln` solution file.

Step 3: Build the Application
-----------------------------
1. In Visual Studio, go to Build > Build Solution or press `Ctrl+Shift+B`.
2. Ensure there are no build errors. If any occur, resolve them based on the error messages.

Step 4: Run the Application
---------------------------
1. Once the build succeeds, press `F5` or click Start Debugging in Visual Studio to run the application.
2. The main window of the CMCS will open, where you can navigate through different functionalities such as Submit Claim, Verify Claims, Upload Documents, and Check Claim Status.

Application Features
--------------------

- Home Screen: Displays the welcome message and basic navigation options.
- Submit Claim: Allows lecturers to submit their claims with details like hours worked, hourly rate, and supporting documents.
- Verify Claims: Coordinators can approve or reject claims.
- Upload Documents: Lecturers can upload documents for their claims.
- Claim Status: Users can search for claims by ID and view the status and history of the claim.

Folder Structure
----------------

The main components of the application are:
- `MainWindow.xaml`: The main UI window.
- `SubmitClaim.xaml`: The window where lecturers submit claims.
- `ClaimStatus.xaml`: The window for checking claim statuses.
- `UploadDocuments.xaml`: The window for uploading claim-related documents.
- `VerifyClaims.xaml`: The window for verifying and managing claims.

Troubleshooting
---------------

- Build errors: Ensure that all required .NET components are installed and properly referenced in the project.
- UI not loading: Ensure that the XAML files are correctly linked to the C# code-behind files.
