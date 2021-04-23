using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    public Rigidbody2D rb;
    private bool isPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if (rb.velocity.sqrMagnitude > 0)
        {
            if(!isPlaying)AudioManager.instance.Play("walk");
            isPlaying = true;
        }
        else
        {
            if(isPlaying)AudioManager.instance.Stop("walk");
            isPlaying = false;
        }
    }
}
