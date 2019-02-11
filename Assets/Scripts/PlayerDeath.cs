using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
/*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            if (MaterialGrabber.material == MaterialGrabber.ICE)
            {
                Death();
            }
            if (MaterialGrabber.material == MaterialGrabber.WOOD)
            {
                Death();
            }
        }
        
        if (other.gameObject.CompareTag("outOfBounds"))
        {
            Death();
        }
    }
    */
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            if (MaterialGrabber.material == MaterialGrabber.ICE)
            {
                Death();
            }
            if (MaterialGrabber.material == MaterialGrabber.WOOD)
            {
                Death();
            }
        }
        
        if (other.gameObject.CompareTag("outOfBounds"))
        {
            Death();
        }
    }

    public static void Death()
    {
        Time.timeScale = 0;
    }
}
