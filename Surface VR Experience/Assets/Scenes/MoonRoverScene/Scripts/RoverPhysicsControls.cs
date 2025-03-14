using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsController : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Rigidbody carRB;
    [SerializeField] private Transform[] rayPoints;
    [SerializeField] private LayerMask ground; 
    [SerializeField] private Transform accelerationPoint; 
    [SerializeField] private GameObject[] tires = new GameObject[4];
    [SerializeField] private GameObject[] fenders = new GameObject[4];

    [SerializeField] private GameObject[] frontTireParents = new GameObject[2];
 

    [Header("Suspensions Settings")]
    [SerializeField] private float springStiffness; // Maximum force our spring can exert, which occurs when it's fully compressed
    [SerializeField] private float damperStiffness; 
    [SerializeField] private float restLength;  // Standard length of our theoretical spring when it's not being compressd/stretched
    [SerializeField] private float springTravel; // Maximum distance our spring can either compress or extend from its normal (rest) postion
    [SerializeField] private float wheelRadius; // 


    private int[] wheelsGrounded = new int[4];
    private bool isGrounded = false; 



    [Header("Input")]
    private float moveInput = 0;
    private float steerInput = 0; 
    private bool brakeInput = false; 


    [Header("Car Settings")]
    [SerializeField] private float acceleration = 25f;
    [SerializeField] private float maxSpeed = 10f; 
    [SerializeField] private float deceleration = 10f; 
    [SerializeField] private float steerStrength = 15f; 
    [SerializeField] private AnimationCurve turningCurve; 
    [SerializeField] private float dragCoefficient = 1f; 
    [SerializeField] private float brakingDeceleration = 100f;
    [SerializeField] private float brakingDragCoefficient = 0.5f; 


    private Vector3 currentCarLocalVelocity = Vector3.zero; 
    private float carVelocityRatio = 0;  

    [Header("Visuals")]
    [SerializeField] private float tireRotationSpeed = 3000f; 
    [SerializeField] private float maxSteeringAngle = 30f; 


    [Header("Input Actions")]
    [SerializeField] private InputActionProperty moveAction;
    [SerializeField] private InputActionProperty steerAction;
    [SerializeField] private InputActionProperty brakeAction;




    #region  Unity Functions

   


    // Start is called before the first frame update
    private void Start()
    {
        
        carRB = GetComponent<Rigidbody>(); 
        carRB.centerOfMass = new Vector3(0, -0.5f, 0); // Lower the center of mass.
        
    }

    private void FixedUpdate()
    {
        Suspension(); 
        GroundCheck(); 
        CalculateCarVelocity(); 
        Movement(); 
        Visuals();
    }

    private void Update()
    {
        GetPlayerInput(); 
    }

    #endregion

    
    #region Input Handling

    private void GetPlayerInput()
    {
        moveInput = moveAction.action.ReadValue<float>();
        steerInput = steerAction.action.ReadValue<float>();

        brakeInput = brakeAction.action.ReadValue<float>() > 0.5f;
    }

    #endregion


    #region Movement

    private void Movement()
    {
        if (isGrounded)
        {
            Acceleration();
            Deceleration(); 
            Turn(); 
            SidewaysDrag();
        }
    }

    private void Acceleration()
    {
        if (Mathf.Abs(currentCarLocalVelocity.z) < maxSpeed)
        {
            carRB.AddForceAtPosition(acceleration * moveInput * carRB.transform.forward, accelerationPoint.position, ForceMode.Acceleration);
        }
        //Debug.Log(currentCarLocalVelocity.z); 
        
    }

    private void Deceleration()
    {

        carRB.AddForce((brakeInput ? brakingDeceleration : deceleration) * carVelocityRatio * -carRB.transform.forward, ForceMode.Acceleration);
    }

    private void Turn()
    {

        carRB.AddRelativeTorque (steerStrength * steerInput * turningCurve.Evaluate(Mathf.Abs(carVelocityRatio)) * Mathf.Sign(carVelocityRatio) * carRB.transform.up, ForceMode.Acceleration);
    }

    private void SidewaysDrag()
    {
        float currentSidewaysSpeed = currentCarLocalVelocity.x; 
        

        float dragMagnitude = -currentSidewaysSpeed *  (brakeInput ? brakingDragCoefficient : dragCoefficient);

        Vector3 dragForce = transform.right * dragMagnitude;

        carRB.AddForceAtPosition(dragForce, carRB.worldCenterOfMass, ForceMode.Acceleration);
    }


    #endregion


    #region Visuals

    private void Visuals()
    {
        TireVisuals(); 
    }

    private void TireVisuals()
    {
        float steeringAngle = maxSteeringAngle * steerInput;
        for (int i = 0; i < tires.Length; i++)
        {
            if (i < 2)
            {
                tires[i].transform.Rotate(Vector3.right, tireRotationSpeed * carVelocityRatio * Time.deltaTime, Space.Self);

                frontTireParents[i].transform.localEulerAngles = new Vector3(frontTireParents[i].transform.localEulerAngles.x, steeringAngle, frontTireParents[i].transform.localEulerAngles.z);

            }

            else
            {
                tires[i].transform.Rotate(Vector3.right, tireRotationSpeed * moveInput * Time.deltaTime, Space.Self);
            }
        }
    }

    private void SetTirePosition(GameObject tire, Vector3 targetPosition)
    {
        tire.transform.position = targetPosition; 
    }

    #endregion


    #region Car Status Check

    private void GroundCheck()
    {
        int tempGroundedWheels = 0;
        for (int i = 0; i < wheelsGrounded.Length; i++)
        {
            tempGroundedWheels += wheelsGrounded[i];

        }

        if(tempGroundedWheels > 1)
        {
            isGrounded = true;
        }

        else
        {
            isGrounded = false; 
        }

    }

    private void CalculateCarVelocity()
    {
        currentCarLocalVelocity = transform.InverseTransformDirection(carRB.velocity);
        carVelocityRatio = currentCarLocalVelocity.z / maxSpeed; 
    }

    #endregion


    #region  Suspension Functions
    private void Suspension()
    {
        for ( int i = 0; i < rayPoints.Length; i++)
        {
            RaycastHit hit; 
            float maxLength =  restLength + springTravel;

            if (Physics.Raycast(rayPoints[i].position, -rayPoints[i].up, out hit, maxLength + wheelRadius, ground))
            {

                wheelsGrounded[i] = 1; 


                float currentSpringLength = hit.distance - wheelRadius; 
                float springCompression = (restLength - currentSpringLength) / springTravel; 

                float springVelocity = Vector3.Dot(carRB.GetPointVelocity(rayPoints[i].position), rayPoints[i].up);

                float dampForce = damperStiffness * springVelocity;

                float springForce = springStiffness * springCompression;    

                float netForce = springForce - dampForce; 

                carRB.AddForceAtPosition(netForce * rayPoints[i].up, rayPoints[i].position);

                //Visuals
                Vector3 tirePos = hit.point + rayPoints[i].up * wheelRadius; 

                SetTirePosition(tires[i], hit.point + rayPoints[i].up * wheelRadius);

                if (fenders[i] != null)
                {
                    fenders[i].transform.position = tirePos + rayPoints[i].up * 0.7f; 
                }

                Debug.DrawLine(rayPoints[i].position, hit.point, Color.red);
            }

            else
            {
                wheelsGrounded[i] = 0; 

                //Visuals

                SetTirePosition(tires[i], rayPoints[i].position - rayPoints[i].up * maxLength);

                Debug.DrawLine(rayPoints[i].position, rayPoints[i].position + (wheelRadius + maxLength) * -rayPoints[i].up, Color.green);

            }
        }
        

    }

    #endregion

    
    public void SetRoverActive(bool isActive)
    {
        if (isActive)
        {
            moveAction.action.Enable();
            steerAction.action.Enable(); 
            brakeAction.action.Enable(); 
        }

        else
        {
            moveAction.action.Disable(); 
            steerAction.action.Disable();
            brakeAction.action.Disable(); 
        }
    }

   
    
    

}
