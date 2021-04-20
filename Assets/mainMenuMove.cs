using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuMove : MonoBehaviour
{

	public GameObject player;

	private void FixedUpdate()
	{
		this.transform.position = player.transform.position;
	}

}
