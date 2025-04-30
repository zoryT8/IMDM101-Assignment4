using UnityEngine;
using System;

public class StreetMover : MonoBehaviour
{
    public static float speed = 10;
    private int currentLevel;
    private static String[] levels = {"Level1 - Easy", "Level2 - Medium", "Level3 - Hard"};

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        if (!PlayerController.gameOver) {
            transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
        }
    }

}

