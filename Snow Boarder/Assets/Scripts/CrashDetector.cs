using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    private ParticleSystem snowParticleSystem;    
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] float loadDelay = 1.3f;
    public bool hasCrashed = true;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground")
        {
            Player player = GetComponent<Player>();
            snowParticleSystem = player.snow;
            snowParticleSystem.Stop();

            if(hasCrashed)
            {
                FindObjectOfType<Player>().DisableControls();
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                hasCrashed = false;
            }
            Invoke("ReloadScene", loadDelay);
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
