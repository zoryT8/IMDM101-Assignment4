using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{

    private float drivingSpeed;
    private Rigidbody rb;
    public Boolean isDrivingTowards = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        String sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Equals("Level1 - Easy")) {
            drivingSpeed = new System.Random().Next(1, 10);
        } else if (sceneName.Equals("Level2 - Medium")) {
            drivingSpeed = new System.Random().Next(30, 60);
        } else if (sceneName.Equals("Level3 - Hard")) {
            drivingSpeed = new System.Random().Next(30, 60);
        }
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
