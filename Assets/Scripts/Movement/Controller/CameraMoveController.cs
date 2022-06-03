using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    public Transform player;
    public float joystickDeadZone = 0.1f;
    public float joystickSensetivity = 1f;
    float xRotation;
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("JoystickX") * joystickSensetivity;
        float  y = Input.GetAxis("JoystickY") * joystickSensetivity;

        if(Input.GetAxis("JoystickX") < joystickDeadZone && Input.GetAxis("JoystickX") > -joystickDeadZone){
            x = 0f;
        }
        if(Input.GetAxis("JoystickY") < joystickDeadZone && Input.GetAxis("JoystickY") > -joystickDeadZone){
            y = 0f;
        }

        xRotation -= y;

        xRotation = Mathf.Clamp(xRotation,-90,90);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        player.Rotate(x * Vector3.up);
    }
}
