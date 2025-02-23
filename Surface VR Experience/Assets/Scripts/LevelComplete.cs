using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] private string nextScene;
    
    public void TurnOffCompletionPanel()
    {
        levelCompletePanel.SetActive(false);
    }

    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
