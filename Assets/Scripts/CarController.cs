using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{

    private float drivingSpeed;
    
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        String sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Equals("Level1 - Easy")) {
            drivingSpeed = new System.Random().Next(0, 10);
        } else if (sceneName.Equals("Level2 - Medium")) {
            drivingSpeed = new System.Random().Next(30, 60);
        } else if (sceneName.Equals("Level3 - Hard")) {
            drivingSpeed = new System.Random().Next(30, 60);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(0, 0, -(drivingSpeed + StreetMover.speed));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerNewCar")) {
            int randomDisplacement = new System.Random().Next(-5, 5);
            GameObject newCar = Instantiate(gameObject, gameObject.transform.position + 
                new Vector3(0, 0, WorldGenerator.distanceToNextStreet + randomDisplacement), Quaternion.identity);
            newCar.transform.Rotate(0, 180, 0);
            Destroy(gameObject);
        }
    }
}
