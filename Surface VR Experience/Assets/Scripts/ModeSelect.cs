using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ModeSelect : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject modeMenu;
    public GameObject modeConfirmationCanvas;
    private Boolean mode;
    
    // Pressing the mode button disables the main menu and shows the mode menu
    public void modeSelectScreen()
    {
        mainMenu.SetActive(false);
        modeMenu.SetActive(true);
    }

    // Clicking "Play" or "Event" pass in false and true, respectively
    // This is recorded so that if the player confirms, the appropriate
    // mode is set
    public void selectMode(bool newMode) 
    {
        modeConfirmationCanvas.SetActive(true);
        mode = newMode;
    }

    // Confirming the mode change modifies GameState and returns to the main menu
    public void confirmMode()
    {
        if (mode == false)
        {
            Debug.Log("In play mode");
            GameState.isEventMode = false;
        }
        else
        {
            Debug.Log("In event mode");
            GameState.isEventMode = true;
        }
        modeConfirmationCanvas.SetActive(false);
        modeMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Declining the mode change simply closes the confirmation panel
    public void declineConfirmation()
    {
        modeConfirmationCanvas.SetActive(false);
    }
}
