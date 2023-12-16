using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] float torqueAmount = 3.5f;
    [SerializeField] float standardSpeed = 15f;
    [SerializeField] float boostSpeed = 25f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.RightArrow))
            surfaceEffector2D.speed = boostSpeed;
        else
            surfaceEffector2D.speed = standardSpeed;
    }
}
