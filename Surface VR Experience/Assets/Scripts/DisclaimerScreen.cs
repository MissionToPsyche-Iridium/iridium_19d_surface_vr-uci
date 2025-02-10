using UnityEngine;
using UnityEngine.SceneManagement;

public class DisclaimerScreen : MonoBehaviour
{
    [SerializeField] private float displayTime = 10f; // Time before transitioning
    [SerializeField] private string nextSceneName = "MainMenu"; 

    void Start()
    {
        Invoke("LoadNextScene", displayTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
