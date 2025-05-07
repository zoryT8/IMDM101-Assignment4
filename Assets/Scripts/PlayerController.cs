using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioClip loseSound;
    private AudioSource audioSource;
    public float constantRunSpeed = 10;
    public float lateralSpeed = 10;
    private float jumpSpeed;
    public GameObject loseText;
    public TextMeshProUGUI scoreText;
    public Button homeButton;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public static Boolean gameOver;
    private Boolean onGround;
    private int currentLevel;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        loseText.SetActive(false);
        homeButton.gameObject.SetActive(false);
        gameOver = false;
        audioSource = GetComponent<AudioSource>();
        onGround = true;
        score = 0;
        WorldGenerator.resetStaticFields();
        WorldGenerator.startingCarRotation = GameObject.Find("Van").transform.rotation;
        WorldGenerator.startingCarY = GameObject.Find("Van").transform.position.y;
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
    }

    void Update()
    {
        if (!gameOver) {
            scoreText.SetText("Score: " + score);
            score++;
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
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpSpeed, 0);
                onGround = false;
            }
            StreetMover.speed += 0.01f;
        }
    }

    void LateUpdate()
    {
        if (!gameOver) {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Car")) {
            if (loseSound != null && audioSource != null) {
                audioSource.PlayOneShot(loseSound);
            }

            Destroy(GameObject.Find("Particle System"));
            Destroy(GameObject.FindGameObjectWithTag("Player"), loseSound != null ? loseSound.length : 0);
            loseText.gameObject.SetActive(true);
            homeButton.gameObject.SetActive(true);
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
        if (!gameOver) {
            WorldGenerator.generateNewStreet();
        }
    }

}
