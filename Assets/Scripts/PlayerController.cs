using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool DebugMode;
    
    private InputMaster playerInput;

    private Rigidbody2D rb;

    private string currentTrigger = "";
    private Collider2D currentTriggerFull = null;
    
    public float speed = 10f;

    void Awake()
    {
        playerInput = new InputMaster();
        rb = GetComponent<Rigidbody2D>();
        playerInput.Player.Interact.performed += Interact;
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if(DebugMode)Debug.Log("Interaction! current trigger: " + currentTrigger);
        
        if (QuestManager.instance.isStoryFinished == false)
        {
            if (currentTriggerFull.name == QuestManager.instance.GetActive().NPC.name) QuestManager.instance.GetActive().NPC.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        
        // ALL INTERACTABLE PLACES GO HERE
        switch (currentTrigger)
        {
            case "Saloon":
                //TODO: Saloon code
                break;
        }
    }

    private void OnEnable()
	{
        playerInput.Enable();
	}

	private void OnDisable()
	{
        playerInput.Disable();
	}

	void FixedUpdate()
    {
        Vector2 moveInput = playerInput.Player.Movement.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(DebugMode)Debug.Log("Entering: "+other.tag);
        currentTrigger = other.tag;
        currentTriggerFull = other;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(DebugMode)Debug.Log("Leaving: "+other.tag);
        currentTrigger = "";
        currentTriggerFull = null;
    }
}
