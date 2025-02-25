using UnityEngine;
using UnityEngine.UI;

public class AutoScrollCredits : MonoBehaviour
{
    public RectTransform creditsPanel;
    public float scrollSpeed = 30f;

    void Update()
    {
        creditsPanel.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}
