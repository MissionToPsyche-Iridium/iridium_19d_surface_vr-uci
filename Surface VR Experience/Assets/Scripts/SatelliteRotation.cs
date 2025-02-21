// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class SatelliteRotation : MonoBehaviour
{
    public float rotationSpeed = 2f; // Speed of rotation

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); // Rotates along the Z-axis
    }
}
