using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private float drivingSpeed;
    private Rigidbody rb;
    public Boolean isDrivingTowards = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        drivingSpeed = new System.Random().Next(30, 60);
    }

    void FixedUpdate()
    {
        if (isDrivingTowards) {
            rb.linearVelocity = new Vector3(0, 0, -drivingSpeed);
        } else {
            rb.linearVelocity = new Vector3(0, 0, drivingSpeed);
        }
        
    }
}
