using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Transform GroundCollisionCheck;
    [SerializeField] private LayerMask GroundMask;
    [Space]
    [SerializeField] private float PlayerSpeed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float JumpForce;
   

    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); 
        MovePlayer();
        MovePlayerCamera();
    }
    
    // Update is called once physics update
    private void FixedUpdate()
    {
       PlayerBody.AddForce(Physics.gravity * 2, ForceMode.Acceleration);
        
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * PlayerSpeed;
        PlayerBody.velocity = new Vector3(moveVector.x, PlayerBody.velocity.y, moveVector.z);
        Debug.Log("YOLO SWAG");
        PlayerBody.rotation = Quaternion.Euler(0f, PlayerCamera.transform.eulerAngles.y, 0f);
         // float targetAngle = Mathf.Atan2(moveVector.x, moveVector.y) * Mathf.Rad2Deg;
         // PlayerBody.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Collider c in Physics.OverlapSphere(GroundCollisionCheck.position, 0.1f, GroundMask))
            {
                Debug.Log(c.name);
            }
           
            
            if (Physics.CheckSphere(GroundCollisionCheck.position, 0.5f, GroundMask))
            {
                PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
    }
    private void MovePlayerCamera()
    {
        
    }
}
