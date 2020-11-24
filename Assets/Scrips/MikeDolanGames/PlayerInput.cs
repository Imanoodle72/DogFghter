using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Allows this class to use the EventManager class
    // The .InputEventFloat is a delegate void in the EventManager class
    public event EventManager.InputEventFloat ForwardEvent;
    public event EventManager.InputEventFloat YawEvent;
    public event EventManager.InputEventFloat PitchEvent;
    public event EventManager.InputEventFloat RollEvent;

    public float deadZone = .15f;

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetKeyboardInput();
        GetMouseInput();
    }

    void GetKeyboardInput()
    {
        // Thrust
        if (ForwardEvent != null)
        {
            if(Input.GetAxis("Throttle") != 0) ForwardEvent(Input.GetAxis("Throttle"));
        }

        // Yaw
        if (YawEvent != null)
        {
            if(Input.GetAxis("Horizontal") != 0) YawEvent(Input.GetAxis("Horizontal"));
        }

        // Pitch
        if (PitchEvent != null)
        {
            if(Input.GetAxis("Vertical") != 0) PitchEvent(Input.GetAxis("Vertical"));
        }

        // Roll
        if (RollEvent != null)
        {
            if(Input.GetAxis("Roll") != 0) RollEvent(Input.GetAxis("Roll"));
        }
    }

    void GetMouseInput()
    {
        // Gets the position of the mouse based on where it is on the game screen
        Vector3 mousePosition = Input.mousePosition;

        // (mousePosition.x - (Screen.width / 2f))
        /* Takes the width of the screen and divides it in half. It then subtracts
        from the mouse position on the x-axis. This detects the distance from the 
        center of the screen in pixles. */
        float yaw = (mousePosition.x - (Screen.width / 2f)) / (Screen.width / 2f);

        // Mathf.
        /* Math library */
        // Abs()
        /* Absolute value function */
        if (Mathf.Abs(yaw) < deadZone) yaw = 0;

        if (YawEvent != null)
        {
            if (yaw != 0) YawEvent(yaw);
        }

        float pitch = (mousePosition.y - (Screen.height / 2f)) / (Screen.height / 2f);

        if (Mathf.Abs(pitch) < deadZone) pitch = 0;

        if (PitchEvent != null)
        {
            if (pitch != 0) PitchEvent(pitch);
        }
    }
}
