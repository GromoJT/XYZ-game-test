using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetController : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    //tsj was here.


    void LateUpdate()
    {
        
        Vector3 desirePosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desirePosition,smoothSpeed);
        transform.position = smoothedPosition;
        //ObsticalDetection();
    }
    /*
    public void ObsticalDetection() 
    {
        Ray ray = Camera.main.ScreenPointToRay(pp);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Œciana!");
        }

    }
    */
}
