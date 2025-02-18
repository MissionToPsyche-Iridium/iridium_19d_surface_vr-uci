using UnityEngine;

public class ObjectApproach : MonoBehaviour
{
    public Transform targetPosition; // The point where the planet should stop
    public float speed = 5f; // Adjust speed to control movement

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition.position) > 0.1f)
        {
            // Move the planet toward the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
        }
    }
}