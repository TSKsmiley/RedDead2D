using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{    
    public Transform refLocation;

    public Animator transition;

    public GameObject FadeToBlack_Box;

    private void Awake()
	{
        FadeToBlack_Box.SetActive(true);
    }
	public void Teleport(Transform playerPos, PlayerController playerScript)
	{
        transition.SetTrigger("Start");
        playerScript.canShoot = !playerScript.canShoot;
        StartCoroutine(WaitForFade(playerPos));
    }

    IEnumerator WaitForFade(Transform playerPos)
    {
        yield return new WaitForSeconds(1F);
        playerPos.position = refLocation.transform.position;
        transition.SetTrigger("End");
    }
}
