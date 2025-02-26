using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using TMPro; //Text mesh pro text is used for the scene image name display

public class CreditsPanel : MonoBehaviour
{

    [SerializeField] private Button CreditsCloseButton;          // Reference to the "Close" button
    [SerializeField] GameObject mainMenu; //Reference to the mainMenu panel
    [SerializeField] GameObject Credits; //Reference to the Credits panel
    [SerializeField] GameObject ObjectInteractionTutorial; //Reference to the Credits panel
    public RectTransform CreditsText;
    public Vector2 originalPosition = new Vector2(0, -350); //the original credit text position from Inspector



    // Pressing the credits button disables the main menu and object interaction tutorial panels and shows the game credits
    public void openCredits()
    {
        mainMenu.SetActive(false);
        ObjectInteractionTutorial.SetActive(false);
        Credits.SetActive(true);

    }

    // Pressing the close button enables the main menu and object interaction tutorial panels closes the game credits
    public void closeCredits()
    {
        mainMenu.SetActive(true);
        ObjectInteractionTutorial.SetActive(true);
        Credits.SetActive(false);
        CreditsText.anchoredPosition = originalPosition;

    }
}
