using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmExitScene : MonoBehaviour
{
    [SerializeField] GameObject confirmExitPanel;

    public void toggleConfirmationPanel()
    {
        confirmExitPanel.SetActive(!confirmExitPanel.activeSelf);
    }
}
