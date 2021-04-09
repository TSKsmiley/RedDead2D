using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using QuestSystem;
using UnityEngine.Assertions.Must;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public bool DebugMode;
    public float speed = 10f;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject aimAssist;
    public Inventory.Controller invController;

    private InputMaster playerInput;

    private Rigidbody2D rb;
    
    private Collider2D currentTrigger = null;

    void Awake()
    {
        playerInput = new InputMaster();
        
        rb = GetComponent<Rigidbody2D>();

        playerInput.Player.Interact.performed += Interact;
        playerInput.Player.Shoot.performed += Shoot;
        playerInput.Player.ControllerShoot.performed += ControllerShoot;
        playerInput.Player.HotbarSel.performed += HotbarSel;
        playerInput.Player.NextHotbar.performed += context => { invController.SelectNext();};
        playerInput.Player.PrevHotbar.performed += context => { invController.SelectPrevious();};
        playerInput.Player.ToggleInv.performed += context => { invController.ToggleInv(); };
    }

    private void HotbarSel(InputAction.CallbackContext obj)
    {
        invController.Select(Int32.Parse(obj.control.name)-1);
    }

	private void Start()
	{
        AudioManager.instance.Play("Music");
	}
	private void ControllerShoot(InputAction.CallbackContext obj)
    {
        Interfaces.IRangedWeapon itemWeapon = invController.GetSelectedItem().Item as Interfaces.IRangedWeapon;
        Debug.Log(itemWeapon);
        itemWeapon.ControllerUse(playerInput);
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        Interfaces.IRangedWeapon itemWeapon = invController.GetSelectedItem().Item as Interfaces.IRangedWeapon;
        Debug.Log(itemWeapon);
        itemWeapon.Use(playerInput);
    }

    private void Reload(InputAction.CallbackContext obj)
    {
        ItemStack item = invController.GetSelectedItem();
        Interfaces.IRangedWeapon weaponItem = item.Item as Interfaces.IRangedWeapon;
        Debug.Log(weaponItem);
    }
    
    private void OnEnable() => playerInput.Enable();
    private void OnDisable() => playerInput.Disable();

    private void Interact(InputAction.CallbackContext obj)
    {
        
        if(DebugMode)Debug.Log("Interaction! current trigger: " + currentTrigger.tag);

        if (DialogueManager.instance.isDialogueStarted == true) {
            DialogueManager.instance.DisplayNextSentence();
            return;
        }

        if (QuestManager.instance.IsDialogueQuest() && currentTrigger != null)
        {
            DialogueQuest activeQ = (DialogueQuest) QuestManager.instance.GetActive();
            if (currentTrigger.name == activeQ.NPC.name)
            {
                activeQ.NPC.GetComponent<DialogueTrigger>().TriggerDialogue(null);
                return;
            }
        }
        
        if (currentTrigger == null) return;
        // ALL INTERACTABLE PLACES GO HERE
        switch (currentTrigger.tag)
        {
            case "Saloon":
                //TODO: Saloon code
                break;
            case "NPC":
                DialogueTrigger diagTrigger = currentTrigger.gameObject.GetComponent<DialogueTrigger>();
                if (diagTrigger.dialogue[0] == null) return;
                
                Dialogue diag = diagTrigger.dialogue[Random.Range(0, diagTrigger.dialogue.Length)];

                for (int i = 0; i < diag.dialogueSegments.Length; i++)
                {
                    diag.dialogueSegments[i].speakerName = diagTrigger.speakerName;
                }

                diagTrigger.TriggerDialogue(diag);
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
            aimAssist.transform.localPosition = aimInput * new Vector2(1f,1f) + new Vector2(0F, 0.4F); // Move the aimassist prefab depending on the input
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
