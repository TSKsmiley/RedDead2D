using UnityEngine.Audio;
using UnityEngine;

// Show in editor
[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0.0f,1.0f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
}