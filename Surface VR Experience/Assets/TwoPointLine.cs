using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TwoPointLine : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pointA;
    public Transform pointB; 
    private LineRenderer line; 


    void Start()
    {
        line = GetComponent<LineRenderer>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        line.positionCount = 2; 
        line.SetPosition(0, pointA.position);
        line.SetPosition(1, pointB.position);
        
    }
}
