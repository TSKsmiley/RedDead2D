using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    public Transform movePoint;

    public Animator transition;

    public GameObject FadeToBlack_Box;

    public float nextTeleportTime = 0F;
    public float teleportCooldown = 1F;


    private void Awake()
	{
        FadeToBlack_Box.SetActive(true);
    }
	public void Teleport(Transform playerPos, PlayerController playerScript)
	{
        if (Time.time >= nextTeleportTime)
        {
            transition.SetTrigger("Start");
            playerScript.canShoot = !playerScript.canShoot;
            StartCoroutine(EnterTimer(playerPos));

            AudioManager.instance.Play("door");
            
            nextTeleportTime = Time.time + 1f / teleportCooldown;
        }
    }

 //   public void ExitBuilding(Transform playerPos, PlayerController playerScript)
	//{
 //       if (Time.time >= nextTeleportTime)
 //       {
 //           transition.SetTrigger("Start");
 //           playerScript.canShoot = !playerScript.canShoot;
 //           StartCoroutine(ExitTimer(playerPos));

 //           nextTeleportTime = Time.time + 1f / teleportCooldown;
 //       }
 //   }

    IEnumerator EnterTimer(Transform playerPos)
	{
        yield return new WaitForSeconds(1F);
        playerPos.position = movePoint.transform.position;
        transition.SetTrigger("End");
    }
    //IEnumerator ExitTimer(Transform playerPos)
    //{
    //    yield return new WaitForSeconds(1F);
    //    playerPos.position = new Vector3(refLocation.x, refLocation.y, refLocation.z);
    //    transition.SetTrigger("End");
    //}
}
