using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class StreetMover : MonoBehaviour
{
    public static float speed = 10;
    private int currentLevel;
    private static String[] levels = {"Level1 - Easy", "Level2 - Medium", "Level3 - Hard"};

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        String sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Equals("Level1 - Easy")) {
            WorldGenerator.distanceToNextStreet = 90;
            speed = 10;
        } else if (sceneName.Equals("Level2 - Medium")) {
            WorldGenerator.distanceToNextStreet = 250;
            speed = 30;
        } else if (sceneName.Equals("Level3 - Hard")) {
            WorldGenerator.distanceToNextStreet = 460;
            speed = 50;
        }
    }

    void Update()
    {
        if (!PlayerController.gameOver) {
            transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
        }
    }

}

