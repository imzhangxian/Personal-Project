using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem crashPS;
    private bool onGround;
    private float speed = 100.0f;
    private float xBound = 20.0f;
    private Rigidbody playerRb;
    private Vector3 freezePos;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstraintPlayerPosition();

    }
    
    // Move player
    private void MovePlayer() 
    {
        if (! GameManager.instance.gameOver) {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            playerRb.AddForce(Vector3.forward * speed * horizontalInput);
            playerRb.AddForce(Vector3.left * speed * verticalInput);

            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                playerRb.AddForce(Vector3.up * speed, ForceMode.Impulse);
                onGround = false;
            }
        }
        else 
        {
            transform.position = freezePos;
        }
    }

    // Constrain the player's position
    private void ConstraintPlayerPosition()
    {
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < - xBound)
        {
            transform.position = new Vector3(- xBound, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with an enemy!");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            // Debug.Log("Game Over!");
            freezePos = transform.position;
            Destroy(other.gameObject);
            crashPS.transform.position = gameObject.transform.position;
            crashPS.Play();
            Destroy(gameObject);
            GameManager.instance.GameOver();
        }
    }
}
