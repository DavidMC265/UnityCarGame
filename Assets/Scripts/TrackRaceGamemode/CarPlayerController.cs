using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlayerController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;
    public float Acceleration = 500f;
    public float BrakingForce= 300f;
    public float maxTurnAngle = 15f;
    private float currentAcceleration = 0f;
    private float currentBrakingForce =0f;
    private float currentTurnAngle = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        currentAcceleration = Acceleration * Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Space)){
            currentBrakingForce = BrakingForce;
        }
        else
        currentBrakingForce = 0f;

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBrakingForce;
        frontLeft.brakeTorque = currentBrakingForce;
        backRight.brakeTorque = currentBrakingForce;
        backLeft.brakeTorque = currentBrakingForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;


    }
}
