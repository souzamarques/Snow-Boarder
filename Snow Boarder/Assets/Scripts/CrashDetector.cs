using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    private ParticleSystem snowParticleSystem;    
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 1.3f;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground")
        {
            Player player = GetComponent<Player>();
            snowParticleSystem = player.snow;
            snowParticleSystem.Stop();

            crashEffect.Play();
            Invoke("ReloadScene", loadDelay);
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
