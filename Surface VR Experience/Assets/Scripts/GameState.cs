using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance {get; private set; }
    public static bool isEventMode = true;
    public static float timeBeforeReset = -1;

    // Number of objects in each scene
    public static int NUMBER_HOBA_OBJECTS = 3;
    public static int NUMBER_HCL_OBJECTS = 5;
    public static int NUMBER_METAL_CRATER_OBJECTS = 3;
    
    // HashSets of infoPanels in each scene. When an object is clicked, they're removed from the HashSet. Reset when "START" is pressed.
    public static HashSet<string> hoba_panels = new HashSet<string> { "Information Panel", "Information Panel2", "Information Panel3" };
    public static HashSet<string> HCL_panels = new HashSet<string> { "Information Panel", "Information Panel1", "Information Panel2", "Information Panel3", "Information Panel4" };
    public static HashSet<string> metal_panels = new HashSet<string> { "Information Panel", "Information Panel2", "Information Panel3" };

    public void toggleMode()
    {
        isEventMode = !isEventMode;
        print("Is event mode: " + isEventMode);
        Debug.Log("Instance ID: " + GetInstanceID());
    }

    public void resetProgress()
    {
        hoba_panels = new HashSet<string> { "Information Panel", "Information Panel2", "Information Panel3" };
        HCL_panels = new HashSet<string> { "Information Panel", "Information Panel1", "Information Panel2", "Information Panel3", "Information Panel4" };
        metal_panels = new HashSet<string> { "Information Panel", "Information Panel2", "Information Panel3" };
    }
}
