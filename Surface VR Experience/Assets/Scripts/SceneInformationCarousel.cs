using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using TMPro; //Text mesh pro text is used for the scene image name display

public class SceneInformationCarousel : MonoBehaviour
{
    [SerializeField] private Image infoCarouselImage;        // Reference to the Image component for displaying images
    [SerializeField] private Sprite[] infoImages;            // Array of Sprites for the carousel
    [SerializeField] private string[] infoSceneNames;       // Array of Scene names
    [SerializeField] private string[] infoSceneDescriptions;  // Array of Scene descriptions
    [SerializeField] private Button infoNextButton;          // Reference to the "Next" button
    [SerializeField] private Button infoPreviousButton;      // Reference to the "Previous" button
    [SerializeField] private Button infoHomeButton;          // Reference to the "Start" button
    [SerializeField] private TMP_Text infoSceneNameText;         // Reference to the Text mesh pro component for the image name
    [SerializeField] private TMP_Text infoSceneDescriptionText;  // Reference to the Text mesh pro component for the image description


    public int infoCurrentIndex = 0;                        // Keeps track of the current image index

    [SerializeField] GameObject mainMenu; //Reference to the mainMenu panel

    [SerializeField] GameObject sceneInformationCarousel; //Reference to the Scene Information carousel



    public void Start()
    {

        if(infoImages.Length != infoSceneNames.Length)
        {
            Debug.LogError("Array length mismatch between images and sceneNames");
            return;
        }

        // Initialize the carousel with the first image
        if (infoImages.Length > 0)
        {
            infoCarouselImage.sprite = infoImages[infoCurrentIndex];
            UpdateImageName(); // Display the initial image name

        }
    }

    // Pressing the information button disables the main menu and shows the information panel
    public void openInfoCarousel()
    {
        mainMenu.SetActive(false);
        sceneInformationCarousel.SetActive(true);

    }

    // Pressing the home button disables the information panel and shows the main menu
    public void closeInfoCarousel()
    {
        mainMenu.SetActive(true);
        sceneInformationCarousel.SetActive(false);
        infoCurrentIndex = 0;

    }

    public void ShowNextImage()
    {
        // Increment the index and wrap around if needed
        infoCurrentIndex = (infoCurrentIndex + 1) % infoImages.Length;
        UpdateImage();
        Debug.Log("Next button clicked");
    }

    public void ShowPreviousImage()
    {
        // Decrement the index and wrap around if needed
        infoCurrentIndex = (infoCurrentIndex - 1 + infoImages.Length) % infoImages.Length;
        UpdateImage();
        Debug.Log("Previous button clicked");
    }

    public void UpdateImage()
    {
        // Update the displayed image based on the current index
        infoCarouselImage.sprite = infoImages[infoCurrentIndex];
        UpdateImageName(); // Update the displayed name


    }

    public void UpdateImageName()
    {
        if (infoImages.Length > 0)
        {
            // Display the name of the current image (use the Sprite name property)
            infoSceneNameText.text = infoImages[infoCurrentIndex].name;
            infoSceneDescriptionText.text = infoSceneDescriptions[infoCurrentIndex];
        }
    }


}