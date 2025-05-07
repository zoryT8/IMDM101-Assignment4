using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class WorldGenerator : MonoBehaviour
{
    public static GameObject street = GameObject.Find("Street1");

    public static int distanceToNextStreet = 90;
    public static float startingCarY;
    public static Quaternion startingCarRotation;
    static int counter = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void resetStaticFields() {
        street = GameObject.Find("Street1");
        counter = 1;
    }

    public static void generateNewStreet() {
        if (counter > 1) {
            deleteOldStreet();
        }

        counter++;

        GameObject newStreet = Instantiate(street, street.transform.position + new Vector3(0, 0, distanceToNextStreet), Quaternion.identity);

        newStreet.name = "Street" + counter;
        street = GameObject.Find(newStreet.name);
    }

    public static void deleteOldStreet() {
        int oldStreetNum = counter - 1;
        Destroy(GameObject.Find("Street" + oldStreetNum));
    }
}
