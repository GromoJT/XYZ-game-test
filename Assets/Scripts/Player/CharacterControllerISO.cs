using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerISO : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 6f;
    float sprintSpeed = 9f;
    bool Grounded;

    Vector3 forward, right;

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

   
    void Update()
    {
        CheckIfGrounded();
        Debug.Log(Grounded);
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s")) Move();
        
    }

    public bool CheckIfGrounded() 
    {

        Grounded = (Physics.Raycast(transform.position, Vector3.down, 2f));

        return Grounded;
            

    }

    void Move() 
    {
        float avaStamina = StaminaBar.instance.getStamina();

        if (Input.GetKey(KeyCode.LeftShift) && avaStamina>0.1f)
        {
            StaminaBar.instance.UseStamina(0.5f);
            
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
            Vector3 righrMovment = right * sprintSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
            Vector3 upMovment = forward * sprintSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
            


            if (Grounded == false)
            {
                righrMovment = righrMovment * 0.5f;
                upMovment = upMovment * 0.5f;
            }


            Vector3 heading = Vector3.Normalize(righrMovment + upMovment);

            transform.forward = heading;
            transform.position += righrMovment;
            transform.position += upMovment;


        }
        else 
        {
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
            Vector3 righrMovment = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
            Vector3 upMovment = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

            if (Grounded == false) 
            {
                righrMovment = righrMovment * 0.5f;
                upMovment = upMovment * 0.5f;
            }

            Vector3 heading = Vector3.Normalize(righrMovment + upMovment);

            transform.forward = heading;
            transform.position += righrMovment;
            transform.position += upMovment;
        }
      
    }
}
