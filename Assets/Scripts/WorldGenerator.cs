using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class WorldGenerator : MonoBehaviour
{
    public static GameObject street = GameObject.Find("Street1");
    public static String[] carNames = {
        "Hatchback",
        "Van",
        "Police",
        "Truck",
        "Pickup",
        "Taxi"
    };
    // public static GameObject hatchback = GameObject.Find("Hatchback1");
    // public static GameObject van = GameObject.Find("Van1");
    // public static GameObject police = GameObject.Find("Police1");
    // public static GameObject truck = GameObject.Find("Truck1");
    // public static GameObject pickup = GameObject.Find("Pickup1");
    // public static GameObject taxi = GameObject.Find("Taxi1");
    public static int distanceToNextStreet = 90;
    static int counter = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void generateNewStreet() {
        if (counter > 1) {
            deleteOldStreet();
        }

        counter++;

        GameObject newStreet = Instantiate(street, street.transform.position + new Vector3(0, 0, distanceToNextStreet), Quaternion.identity);

        // for (int i = 0; i < carNames.Length; i++) {
        //     GameObject car = GameObject.Find(carNames[i] + (counter - 1));
        //     GameObject newCar = Instantiate(car, car.transform.position + new Vector3(0, 0, distanceToNextStreet), Quaternion.identity);
        //     newCar.transform.Rotate(0, 180, 0);
        //     newCar.name = carNames[i] + counter;
        // }

        newStreet.name = "Street" + counter;
        street = GameObject.Find(newStreet.name);
    }

    public static void deleteOldStreet() {
        int oldStreetNum = counter - 1;
        Destroy(GameObject.Find("Street" + oldStreetNum));

        // for (int i = 0; i < carNames.Length; i++) {
        //     Destroy(GameObject.Find(carNames[i] + oldStreetNum));
        // }
    }
}
