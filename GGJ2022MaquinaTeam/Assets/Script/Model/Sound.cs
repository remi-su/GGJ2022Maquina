
using UnityEngine;
using UnityEngine.Audio;
using System;


[Serializable]
public class Sound
{
    public string name;
    [Range(0,1)]
    public float volume;
    [Range(0.3f, 3)]
    public float pithc;
    public bool loop;
    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;
}
