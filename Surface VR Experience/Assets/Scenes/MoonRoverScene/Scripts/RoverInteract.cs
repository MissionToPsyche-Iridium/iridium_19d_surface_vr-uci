using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;


public class RoverEnterInteraction : MonoBehaviour
{
    [Header("References")]
    public XRSimpleInteractable roverInteractable;
    public GameObject playerXROrigin; 
    public Transform roverSeatTransform; //transform positon where player should be at
    public Transform roverExitPosition; 
    public PhysicsController roverController; 
    public CanvasGroup fadeScreen; // fade in/out  




    [Header("Input Actions")]
    public InputActionProperty enterAction;
    public InputActionProperty exitAction; 

    [Header("Settings")]
    public Vector3 exit = new Vector3(0,0, -2f);
    public float fadingDuration = 1f; 

    private bool isHovering = false;
    private bool isInsideRover = false; 


    [Header("Move/Turn Components")]
    public DynamicMoveProvider dynamicMoveProvider;       
    public ActionBasedSnapTurnProvider snapTurnProvider;  

  
    [Header("UI Panels")]
    public GameObject roverHoverTooltip;
    public GameObject inRoverTooltip; 


    void OnEnable()
    {
        roverInteractable.hoverEntered.AddListener(OnHoverEnter);
        roverInteractable.hoverExited.AddListener(OnHoverExit);

        enterAction.action.Enable();
        exitAction.action.Enable(); 
    }

    void OnDisable()
    {
        roverInteractable.hoverEntered.RemoveListener(OnHoverEnter);
        roverInteractable.hoverExited.RemoveListener(OnHoverExit);


        enterAction.action.Disable();
        exitAction.action.Disable(); 
    }

    void Update()
    {
        // Method won't activate unless rover being hovered and enterAction button is pressed

        if (!isInsideRover)
        {
            if (isHovering && enterAction.action.WasPerformedThisFrame())
            {
                EnterRover();
            }
        }

        else 
        {
            if (exitAction.action.WasPerformedThisFrame())
            {
                ExitRover(); 
            }
        }
        
    }

    private void OnHoverEnter(HoverEnterEventArgs arg)
    {
        isHovering = true;

        if (!isInsideRover)
        {
            roverHoverTooltip.SetActive(true); 
        }


        var interactor = arg.interactorObject as XRBaseControllerInteractor;
        if (interactor != null && interactor.xrController != null)
        {
            interactor.xrController.SendHapticImpulse(0.5f, 0.1f);
        }
    }

    private void OnHoverExit(HoverExitEventArgs arg)
    {
        isHovering = false;
        roverHoverTooltip.SetActive(false); 
    }

    private void EnterRover()
    {
        
        StartCoroutine(FadeToBlackAndMovePlayer());
    }


    private bool hasShownBefore = false; 
    private IEnumerator FadeToBlackAndMovePlayer()
    {
        //fade in
        yield return StartCoroutine(Fade(0f, 1f));

    
        // XR rig is placed so that camera/XROrigin is at roverSeatTransform
        playerXROrigin.transform.position = roverSeatTransform.position;
        playerXROrigin.transform.rotation = roverSeatTransform.rotation;

        playerXROrigin.transform.SetParent(roverSeatTransform, worldPositionStays: false);

        playerXROrigin.transform.localScale = Vector3.one;


       roverController.SetRoverActive(true);

       if (dynamicMoveProvider != null) dynamicMoveProvider.enabled = false;
       if (snapTurnProvider != null) snapTurnProvider.enabled = false;



       isInsideRover = true; 

       if (!hasShownBefore)
       {
            inRoverTooltip.SetActive(true);
            hasShownBefore = true; 

            StartCoroutine(HideRoverPanel(10f));
       }

        
       yield return StartCoroutine(Fade(1f, 0f));
    }

    private IEnumerator HideRoverPanel(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        inRoverTooltip.SetActive(false); 
    }


    private void ExitRover()
    {
        StartCoroutine(FadeAndExit());
        
    }

    private IEnumerator FadeAndExit()
    {
        yield return StartCoroutine(Fade(0f, 1f));

        roverController.SetRoverActive(false);

        playerXROrigin.transform.SetParent(null, true);

        playerXROrigin.transform.localScale = Vector3.one;


        Vector3 exitPosition; 
        if (roverExitPosition != null)
        {
            exitPosition = roverExitPosition.position; 
        }

        else
        {
            exitPosition = roverSeatTransform.position + roverSeatTransform.TransformDirection(exit);
        }

        playerXROrigin.transform.position = exitPosition;

        if (dynamicMoveProvider != null) dynamicMoveProvider.enabled = true;
        if (snapTurnProvider != null) snapTurnProvider.enabled = true;

        isInsideRover = false; 


        yield return StartCoroutine(Fade(1f, 0f));

    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsed = 0f;
        while (elapsed < fadingDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadingDuration);
            fadeScreen.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            yield return null;
        }
        fadeScreen.alpha = endAlpha;
        
    }


}
