using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using QuestSystem;

public class PlayerController : MonoBehaviour
{
    public bool DebugMode;
    public float speed = 10f;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject aimAssist;

    public float shootRate = 2f;

    private InputMaster playerInput;

    private Rigidbody2D rb;
    
    private Collider2D currentTrigger = null;

    private float nextShootTime = 0;

    void Awake()
    {
        playerInput = new InputMaster();
        
        rb = GetComponent<Rigidbody2D>();

        playerInput.Player.Interact.performed += Interact;
        playerInput.Player.Shoot.performed += Shoot;
        playerInput.Player.ControllerShoot.performed += ControllerShoot;
    }


	private void Start()
	{
        AudioManager.instance.Play("Music");
	}
	private void ControllerShoot(InputAction.CallbackContext obj) 
    {
        if (Time.time >= nextShootTime) 
        {   
            Vector2 controllerDir = playerInput.Player.ControllerAim.ReadValue<Vector2>();
            if (controllerDir == new Vector2(0,0)) return;

            GameObject g = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            g.GetComponent<Bullet>().MoveBullet(controllerDir.normalized);
            
            nextShootTime = Time.time + 1f / shootRate;
        }
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        if (Time.time >= nextShootTime) 
        {
            Vector2 mousePos = playerInput.Player.Aim.ReadValue<Vector2>();
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector2 direction = mousePos - (Vector2)firePoint.position;

            GameObject g = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            g.GetComponent<Bullet>().MoveBullet(direction.normalized);

            nextShootTime = Time.time + 1f / shootRate;
        }
    }
    
    private void OnEnable() => playerInput.Enable();
    private void OnDisable() => playerInput.Disable();

    private void Interact(InputAction.CallbackContext obj)
    {
        if(DebugMode)Debug.Log("Interaction! current trigger: " + currentTrigger.tag);

        if (QuestManager.instance.isStoryFinished == false)
        {
            DialogueQuest activeQ = (DialogueQuest) QuestManager.instance.GetActive();
            if (currentTrigger.name == activeQ.NPC.name) activeQ.NPC.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        
        // ALL INTERACTABLE PLACES GO HERE
        switch (currentTrigger.tag)
        {
            case "Saloon":
                //TODO: Saloon code
                break;
            case "NPC":
                DialogueManager.instance.DisplayNextSentence();
                break;
        }
    }

	void FixedUpdate()
    {
        Vector2 moveInput = playerInput.Player.Movement.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;

        Vector2 aimInput = playerInput.Player.ControllerAim.ReadValue<Vector2>().normalized;

        // If the player is aiming using a controller
        if (aimInput != new Vector2(0,0)) {
            aimAssist.SetActive(true); // Enable aimassist
            aimAssist.transform.localPosition = aimInput * new Vector2(5f,5f) + new Vector2(0,2.5f); // Move the aimassist prefab depending on the input
        }
        // If the player is not aiming
        else {
            aimAssist.SetActive(false); // Don't show aimassist
        }
        
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
