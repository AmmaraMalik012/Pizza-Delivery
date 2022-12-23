using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Controller : MonoBehaviour
{
    // The maximum speed the car can reach
    public float maxSpeed = 10f;

    // The acceleration of the car
    public float acceleration = 10f;

    // The deceleration of the car when braking
    public float braking = 20f;

    // The maximum steering angle of the car
    public float maxSteeringAngle = 45f;

    // The current speed of the car
    private float currentSpeed;

    // The current steering angle of the car
    private float currentSteeringAngle;

    // The rigidbody component of the car
    private Rigidbody rb;

    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Handle input and update the speed and steering angle
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        currentSpeed += verticalInput * acceleration * Time.deltaTime;
        currentSteeringAngle = horizontalInput * maxSteeringAngle;

        // Clamp the speed to the maximum speed
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Brake the car when the vertical input is negative
        if (verticalInput < 0)
        {
            currentSpeed += braking * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Apply the steering angle and speed to the car
        Quaternion rotation = Quaternion.Euler(0f, currentSteeringAngle, 0f);
        Vector3 movement = rotation * Vector3.forward * currentSpeed;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
