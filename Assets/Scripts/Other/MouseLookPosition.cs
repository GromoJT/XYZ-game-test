using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookPosition : MonoBehaviour
{
    void Update()
    {
        
            Vector3 clickPosition = -Vector3.one;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) 
            {
                clickPosition = hit.point;
            }
            Debug.Log(clickPosition);
        
        
    }
}
