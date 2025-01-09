using UnityEngine;
public class FlickeringLight : MonoBehaviour
{
    public Light flickerLight; // Reference to the Light component
    public float minIntensity = 1000.5f; // Minimum intensity
    public float maxIntensity = 10000f; // Maximum intensity
    public float flickerSpeed = 0.1f; // Light flicker speed

    private float time = 0;

    void Start()
    {
        if (flickerLight == null)
            flickerLight = GetComponent<Light>();
    }

    void Update()
    {
        // Flicker the light by varying intensity
        time += Time.deltaTime * flickerSpeed;
        flickerLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PerlinNoise(time, 0.0f));
    }
}