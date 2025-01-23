using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    //
    [SerializeField] private string nextScene;
    public float remainingTime;

    void Start() {
        if (!GameState.isEventMode) {
            Destroy(gameObject);
        }
        
        // If the user reloaded the scene (as indicated by timeBeforeReset =/= -1), their 
        // remaining time is retrieved so that they can't abuse the reload button to gain more time.
        else if (GameState.timeBeforeReset >= 0)
        {
            remainingTime = GameState.timeBeforeReset;
            GameState.timeBeforeReset = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime < 5)
        {
            timerText.color = Color.red;
        }
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        if (remainingTime <= 0)
        {
            remainingTime = 0;
            //string currentSceneName = SceneManager.GetActiveScene().name;
            //int nextSceneIndex = sceneNames.IndexOf(currentSceneName) + 1;
            SceneManager.LoadScene(nextScene);
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
