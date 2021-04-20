using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [Header("Movement")] 
    public float moveSpeed = 5f;
    public float rotateSpeed = 200f;
    
    private Transform target;
    
    public int health = 100;
    public int damage = 10;
    
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void TakeDamage(int damage) {
        if (health <= 0) {
            QuestManager.instance.GetActive().CheckCompleteConditions(null, this.gameObject);
            Destroy(this.gameObject);
        }

        health -= damage;
    }
    
    void FixedUpdate()
    {
        Vector2 direction = (Vector2) target.position - rb.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) other.GetComponent<PlayerController>().TakeDamage(damage);
    }
}
