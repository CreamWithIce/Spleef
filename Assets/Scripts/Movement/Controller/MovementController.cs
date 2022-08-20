using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
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

    void Update()
    {
        // Sets the players y velocity to be gravity over time
        // Checks if there is ground beneath using a checksphere
        velocity.y += gravity * Time.deltaTime;

        groundCheck = Physics.CheckSphere(jumpCheck.position,size,layer);

        if(groundCheck && velocity.y  < 0){
            velocity.y = -2f;
        }

        // If the player has pressed the jump key (check input manager)
        if(groundCheck && Input.GetButtonDown("ControllerJump")){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        

        // Get the joystick axis for the movement (bound to x axis currently)
        //* NOTE: Currently doesn't work on playstation controllers *

        float x = Input.GetAxis("HorizontalJoystick");
        float z = Input.GetAxis("VerticalJoystick");


        // checks if the controller joystick is moved outside the deadzone
        if(x < joystickDeadZone && x > -joystickDeadZone){
            x = 0f;
        }

        if(z < joystickDeadZone && z > -joystickDeadZone){
            z = 0f;
        }
        
        // Moves the player
        Vector3 move = x * transform.right + z * transform.forward;
        
        player.Move(move * Time.deltaTime * speed);
        player.Move(velocity * Time.deltaTime);
    }
}
