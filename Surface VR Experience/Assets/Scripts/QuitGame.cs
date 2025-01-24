using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [SerializeField] GameObject quitCanvas;

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit.");
    }

    public void confirmIfQuitting()
    {
        if (quitCanvas != null)
        {
            quitCanvas.SetActive(true);
        }
    }

    public void cancelQuitting()
    {
        quitCanvas.SetActive(false);
    }
}
