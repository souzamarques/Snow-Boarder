using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.3f;

    void OnTriggerEnter2D(Collider2D other)
    {
        Invoke("ReloadScene", loadDelay); 
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
