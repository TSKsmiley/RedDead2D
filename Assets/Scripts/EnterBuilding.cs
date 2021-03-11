using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnterBuilding : MonoBehaviour
{
	//private PlayerInput Controls;
	private InputMaster Controls;

	void Awake()
	{
		//playerInput = new InputMaster();
		Controls = GetComponent<InputMaster>();
	}

	private void OnEnable()
	{
		Controls.Enable();
	}

	private void OnDisable()
	{
		Controls.Disable();
	}

	

	private void Update()
	{
		
	}

}
