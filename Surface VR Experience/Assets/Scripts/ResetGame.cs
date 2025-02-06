using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField] GameObject resetUnavailablePanel;
    [SerializeField] GameObject resetConfirmationPanel;
    public void ReloadScene() 
    {
        if (GameState.isEventMode)
        {
            resetUnavailablePanel.SetActive(true);
            // USE THIS CODE IF YOU WANT TO PERMIT RESETTING IN EVENT MODE
            // Stores the remaining time in GameState and then reloads the scene
            /*Timer timer  = FindObjectOfType<Timer>();
            GameState.timeBeforeReset = timer.remainingTime;
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);*/
        }
        else
        {
            resetConfirmationPanel.SetActive(true);
        }
    }

    public void togglePanel()
    {
        resetUnavailablePanel.SetActive(false);
    }

    public void toggleConfirmationPanel()
    {
        resetConfirmationPanel.SetActive(false);
    }

    public void resetScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
