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

    private void Start() {
        Destroy(this, 3f);
    }

    public void MoveBullet(Vector3 pos)
    {
        rb.velocity = pos * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("EnterBuilding"))
        {
            if (!other.CompareTag("NPC"))
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                this.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(this, 1f);

                if (other.CompareTag("Enemy")) {
                    other.GetComponent<Enemy>().TakeDamage(20);
                }
            }
        }
        
    }
}
