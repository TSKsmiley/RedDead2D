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

    public HealthBar healthBar;
    public int currHealth;
    public int maxHealth = 100;
    public float speed = 10f;
    
    // QOL Features
    public GameObject aimAssist;
    public List<GameObject> hideObjectsOnMap;

    public Camera mapCamera;

    private InputMaster playerInput;

    private Rigidbody2D rb;
    
    private Collider2D currentTrigger = null;

    public Animator animator;

    public bool isMapOpen;

    void Awake()
    {
        playerInput = new InputMaster();
        
        rb = GetComponent<Rigidbody2D>();

        playerInput.Player.Interact.performed += Interact;
        playerInput.Player.Use.performed += Use;
        playerInput.Player.Reload.performed += Reload;
        playerInput.Player.ControllerUse.performed += ControllerUse;
        playerInput.Player.Map.performed += openMap;
        playerInput.Player.HotbarSel.performed += HotbarSel;
        playerInput.Player.NextHotbar.performed+= context => { Inventory.Controller.instance.SelectNext(); };
        playerInput.Player.PrevHotbar.performed += context => { Inventory.Controller.instance.SelectPrevious(); };
        playerInput.Player.ToggleInv.performed += context => { Inventory.Controller.instance.ToggleInv(isMapOpen); };
        
        
    }

    private void Start()
    {
        AudioManager.instance.Play("Music");
        
        // CUSTOM EVENTS
        Controller.instance.itemSelectEvent += OnItemSelect;
        
        // HEALTH
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // When a new item is selected
    private void OnItemSelect()
    {
        ItemStack item = Controller.instance.GetSelectedItem();
        if (item == null)
        {
            animator.SetBool("RevolverInHand", false);
            return;
        }
        // Animation shit
        switch (item.Item.name)
        {
            case "Revolver":
                animator.SetBool("RevolverInHand", true);
                break;
                    
            default:
                animator.SetBool("RevolverInHand", false);
                break;
        }
    }

    private void HotbarSel(InputAction.CallbackContext obj)
    {
        Inventory.Controller.instance.Select(Int32.Parse(obj.control.name)-1);
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
        
        if (QuestManager.instance.isStoryComplete == false) QuestManager.instance.GetActive().CheckCompleteConditions(currentTrigger, this.gameObject);
        
        if (currentTrigger == null) return;
        // ALL INTERACTABLE PLACES GO HERE
        switch (currentTrigger.tag)
        {
            case "Teleport": //Enter and exit buildings with transition
                currentTrigger.GetComponent<BuildingInfo>().Teleport(this.transform, this);

                break;

            

            case "NPC":
                if (DialogueManager.instance.isQuestDialogue) return;
                DialogueTrigger diagTrigger = currentTrigger.gameObject.GetComponent<DialogueTrigger>();
                if (diagTrigger.dialogue[0] == null) return;
                
                Dialogue diag = diagTrigger.dialogue[Random.Range(0, diagTrigger.dialogue.Length)];

                for (int i = 0; i < diag.dialogueSegments.Length; i++)
                {
                    diag.dialogueSegments[i].speakerName = diagTrigger.speakerName;
                }

                diagTrigger.TriggerDialogue(diag);
                break;
            
            case "ShopVendor":
                currentTrigger.gameObject.GetComponent<ShopVendor>().OpenShop(rb);
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
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

		
    }

    public void TakeDamage(int _damage)
    {
        if (currHealth <= 0)
        {
            Debug.Log("deed");
        }
        
        currHealth -= _damage;
        healthBar.SetHealth(currHealth);
    }


    void openMap(InputAction.CallbackContext obj)
	{
        if (Inventory.Controller.instance.isOpen == true) return;
        isMapOpen = !isMapOpen;

        mapCamera.enabled = !mapCamera.enabled;
		foreach (GameObject g in hideObjectsOnMap)
		{
            g.SetActive(!g.activeSelf);
		}


		if (hideObjectsOnMap[0].activeSelf == true)
		{
			rb.constraints = RigidbodyConstraints2D.FreezePosition;
		}
		else
		{
			rb.constraints = RigidbodyConstraints2D.None;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
