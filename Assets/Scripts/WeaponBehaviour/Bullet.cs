using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    public float destroyDelay = 2.5F;

    private void Start() 
    {
        StartCoroutine(waitDestroy());
    }

    public void MoveBullet(Vector3 pos)
    {
        rb.velocity = pos * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Teleport"))
        {
            if (!other.CompareTag("NPC"))
            {
				if (!other.CompareTag("Player"))
				{
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    this.GetComponent<SpriteRenderer>().enabled = false; 
                    StartCoroutine(waitDestroy());

                    if (other.CompareTag("Enemy")) 
                    {
                        other.GetComponent<Enemy>().TakeDamage(20);
                    }
				}
                
            }
        }
        
    }

    private IEnumerator waitDestroy()
	{
        yield return new WaitForSeconds(destroyDelay);
        Destroy(this.gameObject);
	}

}
