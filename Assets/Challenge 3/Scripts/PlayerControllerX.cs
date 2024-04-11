using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControllerX : MonoBehaviour
{
    public TextMeshProUGUI countText;

    public bool gameOver;
    

    public float floatForce;
    // private float gravityModifier = 0.8f;
    private Rigidbody playerRb;

    
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    
    public AudioClip bounceSound;

    public float yLowerBound = 1.3f;
    public float yUpperBound = 14.0f;
    public int count;

    
    





    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -7.848f, 0);
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        count = 0;

        SetCountText();

    }

   

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        if (transform.position.y > yUpperBound)
        {
            transform.position = new Vector3(transform.position.x, yUpperBound, transform.position.z);
            playerRb.AddForce(Vector3.down * 2, ForceMode.Impulse);
        }

        // Restricts the ballon from dropping below the ground, bounce, and make a noise.
        if (transform.position.y < yLowerBound)
        {
            transform.position = new Vector3(transform.position.x, yLowerBound, transform.position.z);
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }

    }
    void SetCountText()
    {
        countText.text = "Moneys: $" + count.ToString() + ".00";
    }

    

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            gameOver = true;
           
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Destroy(gameObject);

            SetCountText();
        }


        // if player collides with money10, fireworks
        else if (other.gameObject.CompareTag("Money10"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            count = count + 10;

            SetCountText();

        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money25"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            count = count + 25;

            SetCountText();

        }

        

    }

}
