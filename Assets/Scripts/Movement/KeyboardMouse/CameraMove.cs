using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform player;
    public int sensetivity = 100;
    float xRotation;
    // Locks the cursor so it doesn't move offscreen
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    // Gets the mouse input from the input manager and clamps the rotation along the x axis
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;


        xRotation -= y;

        xRotation = Mathf.Clamp(xRotation,-90,90);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        player.Rotate(x * Vector3.up);
    }
}
