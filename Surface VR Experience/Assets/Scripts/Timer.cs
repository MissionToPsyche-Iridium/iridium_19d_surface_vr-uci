using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] private string nextScene;
    [SerializeField] GameObject inGameMenu;
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] GameObject fullyCompletePanel;

    public float remainingTime;
    private bool showCompletePanel = false;
    private bool completePanelShown = false;
    private float timeToShowCompletePanel = -1;
    private readonly float DelayBetweenCompletionAndPanel = 10; // When progress reaches 100%, the completion panel shows after this amount of time elapses
    private readonly float TimeThresholdForCompletionPanel = 20;   // If the game is completed with at least this much time left on the clock, show the completion panel
    private readonly float  ShowTimerRedTime = 5; // Time when timer turns red

    void Start() {
        if (!GameState.isEventMode) {
            Destroy(gameObject);
        }
        // LEGACY CODE - will delete when i sure it not gonna break anything
        // If the user reloaded the scene (as indicated by timeBeforeReset =/= -1), their 
        // remaining time is retrieved so that they can't abuse the reload button to gain more time.
        else if (GameState.timeBeforeReset >= 0)
        {
            remainingTime = GameState.timeBeforeReset;
            GameState.timeBeforeReset = -1;
        }
    }

    // Update the time, as long as the game isn't paused
    void Update()
    {
        if (inGameMenu != null)
        {
            if (!inGameMenu.activeSelf)
            {
                // If the player completes the level with over <threshold> seconds on the clock, proposition
                // them to move to the next scene after <delay> seconds so they can read the final panel
                if (remainingTime > TimeThresholdForCompletionPanel && !showCompletePanel && GameState.Instance.get_progress(SceneManager.GetActiveScene().name) == 100)
                {
                    showCompletePanel = true;
                    timeToShowCompletePanel = remainingTime - DelayBetweenCompletionAndPanel;
                }
                else if (showCompletePanel && !completePanelShown && remainingTime <= timeToShowCompletePanel)
                {
                    if (fullyCompletePanel && GameState.Instance.get_progress("PsycheHobaCrater") + GameState.Instance.get_progress("PsycheHobaCraterLarge") + GameState.Instance.get_progress("PsycheMetalCraterPOC") + GameState.Instance.get_progress("PsycheSpacecraftSatellite") == 400) {
                        fullyCompletePanel.SetActive(true);
                    }
                    else if (levelCompletePanel) {
                        levelCompletePanel.SetActive(true);
                    }
                    completePanelShown = true;
                }

                if (remainingTime < ShowTimerRedTime)
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
                    SceneManager.LoadScene(nextScene);
                }
                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }
}
