using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit.");
    }
}
