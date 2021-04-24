using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = s.spatialBlend;

            s.source.loop = s.loop;
            
        }
    }

    public AudioSource GetSound(string name)
    {
        Sound s = FindSound(name);

        return s?.source;
    }
    
    public void Play(string name)
    {
        Sound s = FindSound(name);
            
        s?.source.Play();
    }

    public void Stop(string name) {
        Sound s = FindSound(name);

        s?.source.Stop();
    }

    private Sound FindSound(string _name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == _name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return null;
        }

        return s;
    }
}