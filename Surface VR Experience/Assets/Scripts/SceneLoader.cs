using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();
        
        // Reload the current scene by loading it again
        SceneManager.LoadScene(currentScene.name);
    }
}
