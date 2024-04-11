using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject particle;
    public ParticleSystem explosionParticle;
    private AudioSource playerAudio; 
    public AudioClip explodeSound;




    // Start is called before the first frame update
    void Start()
    {

        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }


        if (player == null)
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);

            Invoke("DelayedSceneChange", 4.0f);
        }

    }

   
    private void DelayedSceneChange()
    {


        SceneManager.LoadScene("Game Over");

    }
}
