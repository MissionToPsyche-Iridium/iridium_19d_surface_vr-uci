using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

// Sequential object selection (one at a time instead of all available at once) 
// Tested use with satellite, but not currently in use

// delete if not used

public class SequentialTrigger : TriggerInfoPanel
{
    private static List<MeshCollider> clickableColliders = new List<MeshCollider>();
    private static int currentObjectIndex = -1;
    private bool isSpecialScene = false;

    protected override void Awake()
    {
        base.Awake();
        RegisterClickableCollider();
    }

    private void RegisterClickableCollider()
    {
        if (clickableColliders.Count == 0)
        {

            MeshCollider[] foundColliders = GameObject.FindObjectsOfType<MeshCollider>();
            System.Array.Sort(foundColliders, (a, b) => a.gameObject.name.CompareTo(b.gameObject.name)); // Sort alphabetically
            clickableColliders.AddRange(foundColliders);

            // Disable all the mesh colliders initially
            foreach (var collider in clickableColliders)
            {
                collider.enabled = false;
            }

            if (clickableColliders.Count > 0)
            {
                clickableColliders[0].enabled = true;
            }
        }
    }

    public override void ShowInfoPanel()
    {
        base.ShowInfoPanel();
        ShowNextObject();
    }

    private void ShowNextObject()
    {
        if (currentObjectIndex < clickableColliders.Count)
        {
            if (currentObjectIndex > 0)
            {
                clickableColliders[currentObjectIndex].enabled = false;
                currentObjectIndex++;
            }

            if (currentObjectIndex < clickableColliders.Count)
            {
                clickableColliders[currentObjectIndex].enabled = true;
            }
        }
    }
}
