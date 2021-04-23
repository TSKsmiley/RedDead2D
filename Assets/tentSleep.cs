using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentSleep : MonoBehaviour
{

    public Animator sleepDark;

    public void Sleep()
    {
        AudioManager.instance.Play("sleep");
        sleepDark.SetTrigger("Start");
        StartCoroutine(SleepEnd());
    }


    IEnumerator SleepEnd()
    {
        yield return new WaitForSeconds(3F);
        sleepDark.SetTrigger("End");
    }

}
