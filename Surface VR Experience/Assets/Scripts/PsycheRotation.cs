using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float rotationSpeed = 0.0238f; // Accurate speed based on Psyche's rotation period. This can be toggled in skybox rotation inspector.

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
