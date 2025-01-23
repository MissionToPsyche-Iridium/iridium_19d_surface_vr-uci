using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void ReloadScene() 
    {
        // Stores the remaining time in GameState and then reloads the scene
        Timer timer  = FindObjectOfType<Timer>();
        GameState.timeBeforeReset = timer.remainingTime;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
