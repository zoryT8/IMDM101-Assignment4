using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float constantRunSpeed = 10;
    public float lateralSpeed = 10;
    private float jumpSpeed = 5.0F;
    public GameObject loseText;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private Boolean gameOver;
    private Boolean onGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        loseText.SetActive(false);
        gameOver = false;
        onGround = true;
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
        if (other.gameObject.CompareTag("LevelEnd")) {
            SceneManager.LoadScene("Level2 - Medium");
        }
    }

}
