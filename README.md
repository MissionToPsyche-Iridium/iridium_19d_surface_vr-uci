**Surface VR Experience** <br>

**Disclaimer** <br>
This work was created in partial fulfillment of University of California, Irvine Capstone Courses 191A and 191B. The work is a result of the Psyche Student Collaborations component of NASA’s Psyche Mission (https://psyche.asu.edu). “Psyche: A Journey to a Metal World” [Contract number NNM16AA09C] is part of the NASA Discovery Program mission to solar system targets. Trade names and trademarks of ASU and NASA are used in this work for identification only. Their usage does not constitute an official endorsement, either expressed or implied, by Arizona State University or National Aeronautics and Space Administration. The content is solely the responsibility of the authors and does not necessarily represent the official views of ASU or NASA. <br>

**Overview** <br>
This repository contains the source code, and documentation for the NASA ASU Capstone Project. The project is a collaborative effort between Arizona State University, NASA, and students capstone participants from the University of California, Irvine with the aim to create a virtual reality experience to simulate standing on another planetary body by showcasing the actual data and what is already known about other non-Earth bodies.

**Project Description** <br>
Coming Soon <br>

**Controls** <br>
Coming Soon <br>

**Gameplay** <br>
Coming Soon <br>

**Team Members** <br>
David Branson <br>
Armani Cardenas <br>
Caroline David <br>
Yeseul Lim <br>
Dylan Gilbert Peppard <br>
Jonathan Vigil <br>

**University name** <br>
University of California, Irvine (UCI)

**Screenshots (App)** <br>
Coming Soon <br><br>

**-----------------------------------------------------------------------------------------------------------------------------** <br>
**Building the project** <br>

1. Clone the project on your local system by using the project’s web URL: https://github.com/MissionToPsyche-Iridium/iridium_19d_surface_vr-uci.git <br>
2. Download and install Unity Hub: https://unity.com/download <br>
Note: System Requirements for Unity 6: https://docs.unity3d.com/Manual/system-requirements.html <br>
3. Open the Unity Hub and click on the Installs tab. Install the Unity (2022.3.50f1) LTS editor. <br>
4. In the Unity Hub, click the “Projects” tab, then click the “Add” dropdown menu and select “Add project from disk.” Select the location of your cloned project. <br>
5. The project should now be listed under the projects. Click to open the project. <br>
Note: The first run of the project may take several minutes as it imports and installs the various packages required for the project. <br><br>

**-----------------------------------------------------------------------------------------------------------------------------** <br>
**Frameworks, IDE, Programming languages, and libraries used in the project.** <br>
**Note: This project was developed for the Meta Quest Virtual Reality Headsets (2, 3S, and 3).** <br>

**Game Engine** <br>
Unity Hub 6 <br>
Unity 2022.3.50f1 LTS <br>
Unity Packages: <br>
Universal render pipeline (URP) <br>
Unity XR Hands 1.4.3 <br>
Unity XR Interaction Toolkit 2.6.3 <br>
Unity XR Plugin Management 4.5.0 <br>

**OpenXR Plugins** <br>
Oculus Touch Controller Profile. <br>
Meta Quest Touch Pro Controller Profile. <br>
Hand Interaction Profile. <br>

**Programming Languages** <br>
Any IDE supporting C#. <br>

**Other Tools**
Git, Bash, and Vim <br><br>

**-----------------------------------------------------------------------------------------------------------------------------** <br>
**Enabling development mode on Meta Quest.**
1. Setup and verify an oculus developer account at https://developer.oculus.com/ <br>
2. Download and install Meta Horizon app on iOS or Android to mobile phone. <br>
a. Go to the app add headset to devices (menu/devices/connect new) <br>
b. Select: device/headset settings and turn on developer mode <br>
3. Download and install oculus app for PC, https://www.meta.com/help/quest/pcvr/ <br>
a. Connect headset to the pc via quest using a direct link (best) or air link. Plug into the pc first, then plug into the headset while wearing it.
b. Accept all popups to allow usb debugging. <br>

**Running a scene on the Meta Quest within Unity.** <br>
1. You can now open the quest link and connect to your desktop after enabling development mode for the Meta Quest.<br>
2. Navigate to the desktop view and click. <br>
3. Open Unity and load the project.<br>
4. Press play in Unity to load and run the scene. <br>
5. The scene should run in VR on the headset.<br>
Debug Tip: If the load time of the scene is large, the first run of that scene may prevent the scene from properly displaying. You may need to stop the running scene after a few moments, then press play again. <br>

**Game Installation / Installing APKs to the Meta Quest** <br>
**Note: Steps 1-2 can be skipped by downloading the "19d_surface_vr_uci_Surface_VR_Experience.apk" from this repositorie's build folder.**
1. Build the application for Android, see: https://docs.unity3d.com/6000.0/Documentation/Manual/android-BuildProcess.html <br>
2. Build the project in Unity (open project/file/build settings/build) assuming the platform has been set to Android, and the player settings are properly configured. <br>
3. Install Android SDK Platform tools: https://developer.android.com/tools/releases/platform-tools<br>
4. Open the command console and navigate to the apk’s root directory <br>
5. Ensure device is connected to pc via quest link. <br>
5. Issue the following commands via command line: <br>
$ adb start-server<br>
$ adb install projectname.apk<br>
6. After a moment the APK should install and become available on the headset.<br>
7. Visit the following link for more information and commands for the Android Debug Bridge (ADB): https://developer.android.com/tools/adb <br>

**Running APKs on the Meta Quest Headset** <br>
1. Navigate to Library/applications/unknown sources (found in drop down menu). <br>
2. Click on the application to run. <br><br>


**-----------------------------------------------------------------------------------------------------------------------------** <br>
**Known issues** <br>

**Large Files**
A standard GitHub repository has a file size limit of 100MB. To enable our collaborators to share large files, we will use Github Large File Storage (LFS). <br>
See About Git Large File Storage: https://docs.github.com/en/repositories/working-with-files/managing-large-files/about-git-large-file-storage#pointer-file-format <br>
Collaborators: “If collaborators on your repository don't have Git LFS installed, they won't have access to the original large file. If they attempt to clone your repository, they will only fetch the pointer files, and won't have access to any of the actual data.” See Collaboration with Git Large File Storage: https://docs.github.com/en/repositories/working-with-files/managing-large-files/collaboration-with-git-large-file-storage <br>
Installation: issue “git lfs install” on the branch with the large file. Setup LFS before adding or committing your branch, failure to do so will result in the inability to commit your large file(s). See Installing Git Large File Storage: https://docs.github.com/en/repositories/working-with-files/managing-large-files/installing-git-large-file-storage
Configuration: Git LFS will have to be associated with the large file you want to upload before you can push it. See Configuring Git Large File Storage: https://docs.github.com/en/repositories/working-with-files/managing-large-files/installing-git-large-file-storage <br>
Step-by-step Commit Instructions:
1. Issue ‘git checkout -b your-feature-branch’ <br>
2. Issue ‘git lfs install’ (if you haven't already done so) <br>
2. Issue ‘git lfs track path/to/file’ <br>
3. Issue ‘git add .gitattributes’ <br>
4. Issue ‘add path/to/file’ <br>
5. Issue ‘git commit -m “your commit message”’ <br><br>

**Gameplay Tutorial Video** <br>
Coming Soon <br>

**Acknowledgements** <br>
NASA and Arizona State University for providing this incredible opportunity. <br>
Our Senior capstone course staff. <br>
Open-source contributors whose tools and libraries we've utilized. <br>

**For any inquiries, please contact** <br>
David Branson <br>
Email:      dbransonuci@gmail.com <br>
Linkedin: https://www.linkedin.com/dbransonuci <br><br>

Dylan Peppard <br>
Email:      pepparddylan@yahoo.com <br>
Linkedin: https://www.linkedin.com/in/dylan-peppard-896713132/ <br><br>

Jonathan Vigil <br>
Email:      jvigil1738@gmail.com <br>

Yeseul Lim <br>
Email:      yeseullim1@gmail.com <br>

Armani Cardenas <br>
Email:      armanicardenas12@gmail.com <br>
Linkedin: https://www.linkedin.com/in/armanicardenas <br><br>

Caroline David <br>
Email:      carolinehudavid@gmail.com <br>
Linkedin: https://www.linkedin.com/in/carolinehudavid/ <br><br>

**PSYCHE** <br>
![ascii-art](https://github.com/user-attachments/assets/c1ce6681-3cf1-4fed-b103-555c487d8520)


