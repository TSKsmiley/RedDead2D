using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputMaster playerInput;

    private Rigidbody2D rb;

    public float speed = 10f;

    // Start is called before the first frame update
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

	// Update is called once per frame
	void FixedUpdate()
    {
        Vector2 moveInput = playerInput.Player.Movement.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;
    }
}
