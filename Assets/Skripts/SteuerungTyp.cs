using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteuerungTyp : MonoBehaviour
{
   
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    
    private bool jumpKeyPressed;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {  
        rigidbodyComponent.velocity = new Vector3(horizontalInput * 5, rigidbodyComponent.velocity.y, verticalInput * 5);
        
        if (Physics.OverlapSphere(groundCheckTransform.position,.1f, playerMask).Length == 0) 
        { 
           return;
        }
        if (jumpKeyPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Tor")
            collision.gameObject.GetComponent<Renderer>().material.color = new Color(100, 0, 0);
        
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.name == "Tor")
            other.gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
    }
}
