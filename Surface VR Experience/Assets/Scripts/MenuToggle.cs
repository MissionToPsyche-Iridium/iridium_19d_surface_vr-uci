using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuToggle : MonoBehaviour
{
    public InputActionReference toggleMenuAction;
    public GameObject menu;
    private void Awake()
    {
        if (toggleMenuAction == null)
        {
            // Debug.LogError("ToggleMenuAction is not assigned in the Inspector!");
            return;
        }

        toggleMenuAction.action.Enable();
        toggleMenuAction.action.performed += ToggleMenu;
        menu.SetActive(false);
    }

    private void OnDestroy()
    {
        if (toggleMenuAction != null)
        {
            toggleMenuAction.action.performed -= ToggleMenu;
        }
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        if (menu == null)
        {
            // Debug.LogError("Menu GameObject is not assigned or found!");
            return;
        }

        menu.SetActive(!menu.activeSelf);
    }

    public void ToggleMenu()
    // For the resume button, which doesn't send an argument
    {
        if (menu == null)
        {
            // Debug.LogError("Menu GameObject is not assigned or found!");
            return;
        }

        menu.SetActive(!menu.activeSelf);
    }
}
