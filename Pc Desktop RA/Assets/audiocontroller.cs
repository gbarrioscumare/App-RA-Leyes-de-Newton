using UnityEngine.Audio;
using System;
using UnityEngine;

public class audiocontroller : MonoBehaviour
{


    public Sound[] sounds;
    AudioSource Rep;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
            
    public void Play(string name)
    {
        if (Rep != null)
        {
            Rep.Stop();
        }
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
        //s.source.Stop();
        Rep = s.source;
    }
}
