using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float constantRunSpeed = 10;
    public float lateralSpeed = 10;
    private float jumpSpeed;
    public GameObject loseText;
    public GameObject winText;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private Boolean gameOver;
    private Boolean onGround;
    private int currentLevel;
    private static String[] levels = {"Level1 - Easy", "Level2 - Medium", "Level3 - Hard"};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        loseText.SetActive(false);
        gameOver = false;
        onGround = true;
        String sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Equals("Level1 - Easy")) {
            currentLevel = 0;
            jumpSpeed = 5.0F;
        } else if (sceneName.Equals("Level2 - Medium")) {
            currentLevel = 1;
            jumpSpeed = 7.5F;
        } else if (sceneName.Equals("Level3 - Hard")) {
            currentLevel = 2;
            jumpSpeed = 7.5F;
        }

        if (winText != null) {
            winText.SetActive(false);
        }
    }

    void OnMove(InputValue movementInput) {
        Vector2 movementVector = movementInput.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        if (!gameOver) {
            rb.AddForce(movementX * lateralSpeed, 0.0F, 0.0F);

            if(Input.GetKey(KeyCode.Space) && onGround){
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpSpeed, rb.linearVelocity.z);
                onGround = false;
            }
        }
    }

    void LateUpdate()
    {
        if (!gameOver) {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, constantRunSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Car")) {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            loseText.gameObject.SetActive(true);
            gameOver = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("ground")) {
            onGround = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LevelEnd") && !gameOver) {
            if (currentLevel < levels.Length - 1) {
                SceneManager.LoadScene(levels[currentLevel + 1]);
                currentLevel += 1;
            } else {
                winText.gameObject.SetActive(true);
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                gameOver = true;
            }
        }
    }

}
