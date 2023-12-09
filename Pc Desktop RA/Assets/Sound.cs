using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    //public int name; no se puede por la logica de audiocontroller.Play()

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 2f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
