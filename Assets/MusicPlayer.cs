using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private string[] clips;
    private int clipIndex;

    void Start()
    {
        StartCoroutine(IPlaySound());
    }

    IEnumerator IPlaySound()
    {
        yield return new WaitForSeconds(Random.Range(40f, 60f));

        clipIndex = Random.Range(0, clips.Length);
        AudioManager.instance.Play(clips[clipIndex]);

        yield return new WaitForSeconds(AudioManager.instance.GetSound(clips[clipIndex]).clip.length);
        StartCoroutine(IPlaySound());
    }
}
