using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;
    void Awake()
    {
        if (GameState.tutorialShown)
        {
            tutorialPanel.SetActive(false);
        }
        else
        {
            tutorialPanel.SetActive(true);
        }
        GameState.tutorialShown = true;
    }

    public void ToggleTutorialPanel()
    {
        tutorialPanel.SetActive(!tutorialPanel.activeSelf);
    }
}
