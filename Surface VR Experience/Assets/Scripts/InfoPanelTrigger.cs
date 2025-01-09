using UnityEngine;
using System.Collections;
public class TriggerInfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel; // Reference to the info panel
    private CanvasGroup canvasGroup;              // Canvas Group for fading the panel away on timeout

    private static TriggerInfoPanel currentlyOpenPanel; // Used to close current panel if a new one's opened

    private void Awake()
    {
        // Ensure the info panel is hidden at the start
        if (infoPanel != null)
        {
            canvasGroup = infoPanel.GetComponent<CanvasGroup>();
            infoPanel.SetActive(false);
        }
    }

    public void ShowInfoPanel()
    {

        // Close any open panel
        if (currentlyOpenPanel != null && currentlyOpenPanel != this)
        {
            currentlyOpenPanel.HideInfoPanel();
        }

        // Show the info panel
        if (infoPanel != null)
        {
            infoPanel.SetActive(true);
            canvasGroup.alpha = 1; // Reset alpha to fully visible
            StopAllCoroutines(); // Stop any ongoing fade-out
            StartCoroutine(FadeOutAfterDelay(10f)); // Start fade-out after 10 seconds

            currentlyOpenPanel = this; // Used to close current panel if a new one's opened
        }

    }

    private IEnumerator FadeOutAfterDelay(float delay)
    {
        // Wait for the delay time
        yield return new WaitForSeconds(delay);

        // Fade out over 1 second
        float fadeDuration = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);//(startingValue, endingValue , interpolationFactor)
            yield return null;
        }

        // Set alpha to 0 and deactivate the panel
        canvasGroup.alpha = 0;
        infoPanel.SetActive(false);

        // clear the currently open panel
        if (currentlyOpenPanel == this)
        {
            currentlyOpenPanel = null;
        }
    }


    // To be used when the close button is pressed
    public void HideInfoPanel()
    {
        // Hide the info panel (optional)
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
            StopAllCoroutines(); //terminates fade out coroutine
        }

        // clear the currently open panel
        if (currentlyOpenPanel == this)
        {
            currentlyOpenPanel = null;
        }
    }
}
