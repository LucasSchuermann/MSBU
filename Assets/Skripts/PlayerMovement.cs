using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [FormerlySerializedAs("rigidbodyComponent")] [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform PlayerCamera;
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
       
        
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * PlayerSpeed;
        PlayerBody.velocity = new Vector3(moveVector.x, PlayerBody.velocity.y, moveVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
    private void MovePlayerCamera()
    {
        PlayerBody.rotation = Quaternion.Euler(0f, PlayerCamera.transform.eulerAngles.y, 0f);
    }
}
