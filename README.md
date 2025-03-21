**Psyche 16: Expedition VR** <br>

**Disclaimer** <br>
This work was created in partial fulfillment of University of California, Irvine Capstone Courses 191A and 191B. The work is a result of the Psyche Student Collaborations component of NASA’s Psyche Mission (https://psyche.asu.edu). “Psyche: A Journey to a Metal World” [Contract number NNM16AA09C] is part of the NASA Discovery Program mission to solar system targets. Trade names and trademarks of ASU and NASA are used in this work for identification only. Their usage does not constitute an official endorsement, either expressed or implied, by Arizona State University or National Aeronautics and Space Administration. The content is solely the responsibility of the authors and does not necessarily represent the official views of ASU or NASA. <br>

**Overview** <br>
This repository contains the source code, and documentation for the NASA ASU Capstone Project. The project is a collaborative effort between Arizona State University, NASA, and students capstone participants from the University of California, Irvine with the aim to create a virtual reality experience to simulate standing on another planetary body by showcasing the actual data and what is already known about other non-Earth bodies.<br>

**Project Description** <br>
Psyche 16: Expedition VR is a first person VR simulation of the surface and orbit of Asteroid 16 Psyche, as well as, the surface of the Moon. The project  features two gameplay modes: event mode (timed levels), and play mode (untimed levels). Players may select from a variety of scenes, from the base of a deep metallic crater, to flying through space as the Psyche Spacecraft orbits the Asteroid Psyche. Players are immersed in a 360 degree virtual world where they interact with objects to learn more about them. Discover all of the objects in the game to win!<br>

---

**Controls** <br>
Menu Interaction / Object interaction: Left Controller Trigger or Right Controller Trigger.  <br>
Player Movement: Player is stationary on all scenes except for the Moon scene. <br>
Camera Movement: Camera movement is tied to the position of the VR headset. Players may look in all directions and turn their body to view a full 360 degree environment. <br>
In-Game Menu / Pause: Left controller menu button. <br>

**Gameplay** <br>

***Main Menu:***  From the main menu, users may view information about each scene by pressing the “i” button. Users may select from event and play modes. Users may cycle through game scenes then press play to begin the scene that is currently displayed on the scene carousel. A game tutorial panel is visible from the main menu. <br>
![MainMenu](https://github.com/user-attachments/assets/fedf516b-d201-4ee3-b772-563710acc2ee)

***Event Mode:*** This is the default mode. In event mode, the user is given two minutes to explore and interact with each scene. After two minutes, the game will transition to the next scene. The user may also move to the next scene by interacting with all objects on that scene. <br>

***Play Mode:*** This mode allows players to spend unlimited time within the game scenes.<br>
![Play Mode](https://github.com/user-attachments/assets/ca62a2dd-93d5-4cbf-a1ae-3a7265ae79fa)

***In-Game Menu:*** While playing a scene, the user may press the left controller menu button to pause, restart, or quit and return to the main menu. Restart is unavailable on event mode.<br>
![Event In-Game Menu](https://github.com/user-attachments/assets/0a44458c-5557-4009-af75-1bd15e0c2461)

***Scene Progress:*** Progress within a scene is displayed at the top-center of the player’s camera as a percentage of the number of objects that have been interacted with. Upon 100% completion, the game will allow the player to read their current information panel, then a new popup will appear prompting them to either continue to the next scene, or remain on the same scene.

***Object interaction:*** Interactable objects are located within each game scene. They can be identified by yellow strobing lights. Once the player hovers over an interactable object with their controller, it will vibrate, and the raycast will change color from white to blue. Clicking on an object will prompt an information panel to popup that will automatically close after 10 seconds.
![Object Interaction Tutorial (when first open scene)](https://github.com/user-attachments/assets/f0a74310-c46d-4be0-b9c0-d1faac6e0dae)

---

**Screenshots (App)** <br>
![image](https://github.com/user-attachments/assets/824652ae-f72d-4673-9d9b-25a98bd258cc)
![HobaCraterLarge](https://github.com/user-attachments/assets/095ebd9a-7e8b-4e4e-a8d2-a37b0f83b80b)
![PsycheSpacecraft](https://github.com/user-attachments/assets/a6daf459-e63f-4255-b42f-db7f377e41bf)
![Moon-Rover](https://github.com/user-attachments/assets/bfb8a1b1-d77e-4c5f-aa5c-ff22563f2226)
<br><br>

**Gameplay Teaser Video** <br>
https://youtu.be/xbsoMsiqtd0<br>

---

**Building the project** <br>

1. Clone the project on your local system by using the project’s web URL: https://github.com/MissionToPsyche-Iridium/iridium_19d_surface_vr-uci.git <br>
2. Download and install Unity Hub: https://unity.com/download <br>
Note: System Requirements for Unity 6: https://docs.unity3d.com/Manual/system-requirements.html <br>
3. Open the Unity Hub and click on the Installs tab. Install the Unity (2022.3.50f1) LTS editor. <br>
4. In the Unity Hub, click the “Projects” tab, then click the “Add” dropdown menu and select “Add project from disk.” Select the location of your cloned project. <br>
5. The project should now be listed under the projects. Click to open the project. <br>
Note: The first run of the project may take several minutes as it imports and installs the various packages required for the project. <br><br>

---

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

---

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
**Note: Steps 1-2 can be skipped by downloading the "19d_surface_vr_uci_Surface_VR_Experience.apk" from this repositorie's root directory.**
1. Build the application for Android, see: https://docs.unity3d.com/6000.0/Documentation/Manual/android-BuildProcess.html <br>
2. Build the project in Unity (open project/file/build settings/build) assuming the platform has been set to Android, and the player settings are properly configured. <br>
3. Install Android SDK Platform tools: https://developer.android.com/tools/releases/platform-tools<br>
4. Open the command console and navigate to the apk’s root directory <br>
5. Issue the following command via command line: <br>
$ adb start-server<br>
6. Ensure device is connected to pc via quest link and accept all requests to enable debugging on the headset.<br>
7. Issue the following command via command line: <br>
$ adb install projectname.apk<br>
8. After a moment the APK should install and become available on the headset.<br>
9. Visit the following link for more information and commands for the Android Debug Bridge (ADB): https://developer.android.com/tools/adb <br>

**Running APKs on the Meta Quest Headset** <br>
1. Navigate to Library/applications/unknown sources. <br>
2. Click on the application to run. <br><br>

---

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
4. Issue ‘git add path/to/file’ <br>
5. Issue ‘git commit -m “your commit message”’ <br><br>

---

**Team Members** <br>
David Branson <br>
Armani Cardenas <br>
Caroline David <br>
Yeseul Lim <br>
Dylan Gilbert Peppard <br>
Jonathan Vigil <br>

**University name** <br>
University of California, Irvine (UCI)

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
Email:      jvigil1738@gmail.com <br><br>

Yeseul Lim <br>
Email:      yeseullim1@gmail.com <br><br>

Armani Cardenas <br>
Email:      armanicardenas12@gmail.com <br>
Linkedin: https://www.linkedin.com/in/armanicardenas <br><br>

Caroline David <br>
Email:      carolinehudavid@gmail.com <br>
Linkedin: https://www.linkedin.com/in/carolinehudavid/ <br><br>

**PSYCHE** <br>
![ascii-art](https://github.com/user-attachments/assets/c1ce6681-3cf1-4fed-b103-555c487d8520)


