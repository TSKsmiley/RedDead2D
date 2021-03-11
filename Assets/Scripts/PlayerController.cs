using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputMaster playerInput;

    private Rigidbody2D rb;

    public float speed = 10f;

    void Awake()
    {
        playerInput = new InputMaster();
        rb = GetComponent<Rigidbody2D>();
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Saloon" && playerInput.Player.Interact.triggered)
        {
            Debug.Log("Pressed E inside collider");
        }
    }


}
