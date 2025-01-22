using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance {get; private set; }
    public static bool isEventMode = true;


    public void toggleMode()
    {
        isEventMode = !isEventMode;
        print("Is event mode: " + isEventMode);
        Debug.Log("Instance ID: " + GetInstanceID());
    }
}
