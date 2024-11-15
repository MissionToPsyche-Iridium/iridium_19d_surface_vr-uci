using UnityEngine;
using UnityEngine.UI;

public class ImageCarousel : MonoBehaviour
{
    [SerializeField] private Image carouselImage;        // Reference to the Image component for displaying images
    [SerializeField] private Sprite[] images;            // Array of Sprites for the carousel
    [SerializeField] private Button nextButton;          // Reference to the "Next" button
    [SerializeField] private Button previousButton;      // Reference to the "Previous" button

    public int currentIndex = 0;                        // Keeps track of the current image index

    public void Start()
    {
        // Initialize the carousel with the first image
        if (images.Length > 0)
        {
            carouselImage.sprite = images[currentIndex];
        }
    }

    public void ShowNextImage()
    {
        // Increment the index and wrap around if needed
        currentIndex = (currentIndex + 1) % images.Length;
        UpdateImage();
        Debug.Log("Next button clicked");
    }

    public void ShowPreviousImage()
    {
        // Decrement the index and wrap around if needed
        currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        UpdateImage();
        Debug.Log("Previous button clicked");
    }

    public void UpdateImage()
    {
        // Update the displayed image based on the current index
        carouselImage.sprite = images[currentIndex];
    }
}