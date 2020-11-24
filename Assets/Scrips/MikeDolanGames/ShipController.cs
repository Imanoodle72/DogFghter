using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public PlayerInput playerInput;

    public float forwardThrustPower = 1000f;
    public float yawSpeed = 1000f;
    public float pitchSpeed = 1000f;
    public float rollSpeed = 1000f;

    public float invertModifier = -1;

    Rigidbody myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();

        playerInput.ForwardEvent += ForwardThrust;
        playerInput.YawEvent += YawMovement;
        playerInput.PitchEvent += PitchMovement;
        playerInput.RollEvent += RollMovement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForwardThrust(float thrust)
    {
        myRigidBody.AddForce(gameObject.transform.forward * thrust * forwardThrustPower * Time.deltaTime);
    }

    public void YawMovement(float yaw)
    {
        myRigidBody.AddTorque(gameObject.transform.up * yaw * yawSpeed * Time.deltaTime);
    }

    public void PitchMovement(float pitch)
    {
        myRigidBody.AddTorque(gameObject.transform.right * pitch * invertModifier * pitchSpeed * Time.deltaTime);
    }
    public void RollMovement(float roll)
    {
        myRigidBody.AddTorque(gameObject.transform.forward * roll * rollSpeed * Time.deltaTime);
    }
}
