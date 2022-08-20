using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController player;
    public float joystickDeadZone = 0.1f;
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    [Header("Ground Checks")]
    public float size = 0.4f;
    public LayerMask layer;
    public Transform jumpCheck;
    bool groundCheck;

    // sets the velocity of the player to be gravity over time
    // Also checks if we are on the ground to jump again

    // Gets input from the horizontal and vertical input axis (check the input manager) and moves the player in that direction
    void Update()
    {
        velocity.y += gravity * Time.deltaTime;

        groundCheck = Physics.CheckSphere(jumpCheck.position,size,layer);

        if(groundCheck && velocity.y  < 0){
            velocity.y = -2f;
        }

        if(groundCheck && Input.GetButtonDown("Jump")){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        Vector3 move = x * transform.right + z * transform.forward;
        
        player.Move(move * Time.deltaTime * speed);
        player.Move(velocity * Time.deltaTime);
    }
}
