using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // need to add to switch to new screen


public class MainMenuController : MonoBehaviour
{
    // public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        playerAudio.PlayOneShot(moneySound);
        // Debug.Log("Button is pressed");
        // fireworksParticle.Play();
        // playerAudio.PlayOneShot(moneySound, 1.0f);
        SceneManager.LoadScene("Challenge 3");
    }

}  // class

















  
