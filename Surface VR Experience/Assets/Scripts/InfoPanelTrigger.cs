using UnityEngine;
using System.Collections;
public class TriggerInfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel; // Reference to the info panel
    private CanvasGroup canvasGroup;              // Canvas Group for fading the panel away on timeout

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
        // Show the info panel
        if (infoPanel != null)
        {
            infoPanel.SetActive(true);
            canvasGroup.alpha = 1; // Reset alpha to fully visible
            StopAllCoroutines(); // Stop any ongoing fade-out
            StartCoroutine(FadeOutAfterDelay(10f)); // Start fade-out after 10 seconds
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

        // Ensure alpha is 0 and deactivate the panel
        canvasGroup.alpha = 0;
        infoPanel.SetActive(false);
    }


    //to be used when the close button is pressed
    public void HideInfoPanel()
    {
        // Hide the info panel (optional)
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}
