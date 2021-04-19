using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using QuestSystem;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public bool DebugMode;

    public bool canShoot = true;

    public float speed = 10f;
    
    // QOL Features
    public GameObject aimAssist;
    public GameObject ammo;

    private InputMaster playerInput;

    private Rigidbody2D rb;
    
    private Collider2D currentTrigger = null;

    void Awake()
    {
        playerInput = new InputMaster();
        
        rb = GetComponent<Rigidbody2D>();

        playerInput.Player.Interact.performed += Interact;
        playerInput.Player.Use.performed += Use;
        playerInput.Player.Reload.performed += Reload;
        playerInput.Player.ControllerUse.performed += ControllerUse;
        playerInput.Player.HotbarSel.performed += HotbarSel;
        playerInput.Player.NextHotbar.performed += context => { Inventory.Controller.instance.SelectNext();};
        playerInput.Player.PrevHotbar.performed += context => { Inventory.Controller.instance.SelectPrevious();};
        playerInput.Player.ToggleInv.performed += context => { Inventory.Controller.instance.ToggleInv(); };
    }

    private void HotbarSel(InputAction.CallbackContext obj)
    {
        Inventory.Controller.instance.Select(Int32.Parse(obj.control.name)-1);
    }

	private void Start()
	{
        AudioManager.instance.Play("Music");
	}

    private void ControllerUse(InputAction.CallbackContext obj)
    {
        ItemStack item = Inventory.Controller.instance.GetSelectedItem();
        if (item != null) item.Item.ControllerUse(playerInput, this.gameObject);
        
    }
    private void Use(InputAction.CallbackContext obj)
    {
        ItemStack item = Inventory.Controller.instance.GetSelectedItem();
        if (item != null) item.Item.Use(playerInput, this.gameObject);
    }

    private void Reload(InputAction.CallbackContext obj)
    {
        Item item = Inventory.Controller.instance.GetSelectedItem()?.Item; // We get the selected item and nullcheck it to avoid errors
        RangedWeaponItem weapon = item as RangedWeaponItem; // We cast the item to a rangedweapon as we know only rangedweapons are capable of shooting
        
        if (weapon != null) weapon.Reload(); // If the weapon is not null (aka we are trying to reload an empty slot or a non ranged weapon) we can safely perform a reload
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
            case "Teleport": //Enter and exit buildings with transition
                currentTrigger.GetComponent<BuildingInfo>().Teleport(this.transform, this);

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
