using UnityEngine;

public class SmoothFlashingOutline : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 1f; 
    [SerializeField] private Color outlineColor = Color.yellow; 
    [SerializeField] private float outlineWidth = 5f; 

    private Outline outline;
    private float targetAlpha = 0f; 
    private bool isFadingIn = true;

    private void Start()
    {
        outline = GetComponent<Outline>();

        if (outline == null)
        {
            outline = gameObject.AddComponent<Outline>();
        }

        outline.OutlineColor = outlineColor; 
        outline.OutlineWidth = outlineWidth; 
    }

    private void Update()
    {
        float alpha = outline.OutlineColor.a;
        if (isFadingIn)
        {
            alpha += fadeSpeed * Time.deltaTime;
            if (alpha >= 1f)
            {
                alpha = 1f;
                isFadingIn = false;
            }
        }
        else
        {
            alpha -= fadeSpeed * Time.deltaTime;
            if (alpha <= 0f)
            {
                alpha = 0f;
                isFadingIn = true;
            }
        }
        outline.OutlineColor = new Color(outlineColor.r, outlineColor.g, outlineColor.b, alpha);
    }
}
