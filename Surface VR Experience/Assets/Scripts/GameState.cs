using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditorInternal;
#endif

public class GameState : MonoBehaviour
{
    //public static GameState Instance {get; private set; }
    public static bool isEventMode = true;
    public static float timeBeforeReset = -1;

    // Number of objects in each scene
    public readonly static int NumberHobaObjects = 3;
    public readonly static int NumberHCLObjects = 5;
    public readonly static int NumberMetalCraterObjects = 3;
    public readonly static int NumberSpacecraftObjects = 6;
    
    // HashSets of infoPanels in each scene. When an object is clicked, they're removed from the HashSet. Reset when "START" is pressed.
    public static HashSet<string> hoba_panels = new HashSet<string> { "Information Panel", "Information Panel2", "Information Panel3" };
    public static HashSet<string> HCL_panels = new HashSet<string> { "Information Panel", "Information Panel1", "Information Panel2", "Information Panel3", "Information Panel4" };
    public static HashSet<string> metal_panels = new HashSet<string> { "Information Panel", "Information Panel2", "Information Panel3" };
    public static HashSet<string> spacecraft_panels = new HashSet<string> { "Information Panel Asteroid", "Information Panel Magnet", "Information Panel Magnet2", "Information Panel DSOC", "Information Panel Neutron", "Information Panel Magnet3" };

    // Used by Progress.cs to calculate the number of remaining unclicked objects over the total number in the scene.
    private Dictionary<string, (HashSet<string>, int)> scene_interactables_and_count;

    // Singleton is implemented without using Awake() so that GameState doesn't need to be active in every scene.
    public static GameState Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("GameState");
                _instance = obj.AddComponent<GameState>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public static GameState _instance;

    private GameState()
    {
        scene_interactables_and_count = new Dictionary<string, (HashSet<string>, int)>
        {
            { "PsycheHobaCrater", (hoba_panels, NumberHobaObjects) },
            { "PsycheHobaCraterLarge", (HCL_panels, NumberHCLObjects)},
            { "PsycheMetalCraterPOC", (metal_panels, NumberMetalCraterObjects)},
            { "PsycheSpacecraftSatellite", (spacecraft_panels, NumberSpacecraftObjects) }
        };
    }

    public void toggleMode()
    {
        isEventMode = !isEventMode;
        print("Is event mode: " + isEventMode);
        Debug.Log("Instance ID: " + GetInstanceID());
    }

    public void resetProgress()
    {
        hoba_panels.UnionWith(new string[] { "Information Panel", "Information Panel2", "Information Panel3" });
        HCL_panels.UnionWith(new string[] { "Information Panel", "Information Panel1", "Information Panel2", "Information Panel3", "Information Panel4" });
        metal_panels.UnionWith(new string[] { "Information Panel", "Information Panel2", "Information Panel3" });
        spacecraft_panels.UnionWith(new string[] { "Information Panel Asteroid", "Information Panel Magnet", "Information Panel Magnet2", "Information Panel DSOC", "Information Panel Neutron", "Information Panel Magnet3" });
    }

    public int get_progress(string scene_name)
    {
       (float unclicked_objects, float num_objects) = (scene_interactables_and_count[scene_name].Item1.Count, scene_interactables_and_count[scene_name].Item2);
        return (int)((num_objects-unclicked_objects)/num_objects*100);
    }
}
