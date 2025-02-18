using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationPeriodY = 120f; // Full Y rotation in 120 sec
    public float rotationPeriodZ = 60f;  // Full Z rotation in 60 sec

    void Update()
    {
        float angleY = (360f / rotationPeriodY) * Time.time;
        float angleZ = (360f / rotationPeriodZ) * Time.time;

        transform.rotation = Quaternion.Euler(0, angleY, angleZ);
    }
}
