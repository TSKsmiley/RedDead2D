using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool DebugMode;
    public float speed = 10f;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    
    private InputMaster playerInput;

    private Rigidbody2D rb;
    
    private Collider2D currentTrigger = null;

    void Awake()
    {
        playerInput = new InputMaster();
        
        rb = GetComponent<Rigidbody2D>();

        playerInput.Player.Interact.performed += Interact;
        playerInput.Player.Shoot.performed += Shoot;
    }


    private void Shoot(InputAction.CallbackContext obj)
    {
        Vector2 mousePos = playerInput.Player.Aim.ReadValue<Vector2>();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        GameObject g = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        g.GetComponent<Bullet>().MoveBullet(mousePos.normalized);
    }
    
    private void OnEnable() => playerInput.Enable();
    private void OnDisable() => playerInput.Disable();

    private void Interact(InputAction.CallbackContext obj)
    {
        if(DebugMode)Debug.Log("Interaction! current trigger: " + currentTrigger.tag);
        
        if (QuestManager.instance.isStoryFinished == false)
        {
            if (currentTrigger.name == QuestManager.instance.GetActive().NPC.name) QuestManager.instance.GetActive().NPC.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        
        // ALL INTERACTABLE PLACES GO HERE
        switch (currentTrigger.tag)
        {
            case "Saloon":
                //TODO: Saloon code
                break;
        }
    }
    
	void FixedUpdate()
    {
        Vector2 moveInput = playerInput.Player.Movement.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(DebugMode)Debug.Log("Entering: "+other.tag);
        currentTrigger = other;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(DebugMode)Debug.Log("Leaving: "+other.tag);
        currentTrigger = null;
    }
}
